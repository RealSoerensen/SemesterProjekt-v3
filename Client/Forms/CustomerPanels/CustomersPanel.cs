﻿using Client.Controllers;
using Models;

namespace Client.Forms.CustomerPanels;

public partial class CustomersPanel : Form
{
    private List<Customer> customers = new();
    private Customer? selectedCustomer;
    private readonly CustomerController customerController = new();
    private readonly AddressController addressController = new();
    private readonly UserAccountController userAccountController = new();

    public CustomersPanel()
    {
        InitializeComponent();
    }

    private async void CustomersPanel_Load(object sender, EventArgs e)
    {
        customers = await customerController.GetAll();
        InitializeDataGridView();
    }

    private void InitializeDataGridView()
    {
        customerGrid.Name = "Customers";
        customerGrid.DataSource = customers;
    }

    private async void RefreshCustomers()
    {
        var firstDisplayedScrollingRowIndex = customerGrid.FirstDisplayedScrollingRowIndex;
        var selectedRowIndex = -1;
        if (customerGrid.SelectedRows.Count > 0)
        {
            selectedRowIndex = customerGrid.SelectedRows[0].Index;
        }

        customerGrid.DataSource = null;
        customers = await customerController.GetAll();
        customerGrid.DataSource = customers;

        try
        {
            if (firstDisplayedScrollingRowIndex >= 0)
            {
                customerGrid.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
            }
            if (selectedRowIndex >= 0 && selectedRowIndex < customerGrid.Rows.Count)
            {
                customerGrid.Rows[selectedRowIndex].Selected = true;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(@"Error while trying to restore grid position and selection: " + ex.Message);
        }
    }

    private void customerGrid_SelectionChanged(object sender, EventArgs e)
    {
        if (customerGrid.SelectedRows.Count <= 0) return;
        var selectedRow = customerGrid.SelectedRows[0];
        selectedCustomer = selectedRow.DataBoundItem as Customer;
    }

    private async void buttonCreate_Click(object sender, EventArgs e)
    {
        var createCustomer = new CreateCustomer();
        createCustomer.ShowDialog();
        if (createCustomer.DialogResult != DialogResult.OK) return;
        RefreshCustomers();
    }

    private void buttonEdit_Click(object sender, EventArgs e)
    {
        EditMethod();
    }

    private async void EditMethod()
    {
        if (selectedCustomer == null)
        {
            MessageBox.Show("Vælg en kunde");
            return;
        }

        try
        {
            var selectedCustomerAddress = await addressController.Get((long)selectedCustomer.AddressID!);
            if (selectedCustomerAddress == null)
            {
                MessageBox.Show("Kunne ikke hente kundens adresse");
                return;
            }

            var selectedCustomerAccount = await userAccountController.Get(selectedCustomer.ID);
            if (selectedCustomerAccount == null)
            {
                MessageBox.Show("Kunne ikke hente kundens brugeroplysninger");
                return;
            }

            var editCustomer = new EditCustomer(selectedCustomer, selectedCustomerAddress, selectedCustomerAccount);
            editCustomer.ShowDialog();

            if (editCustomer.DialogResult != DialogResult.OK) return;
            var customer = editCustomer.Customer;
            var address = editCustomer.Address;
            var account = editCustomer.UserAccount;
            bool customerUpdated = await customerController.Update(customer);
            bool addressUpdated = await addressController.Update(address);
            bool accountUpdated = await userAccountController.Update(account);
            if (customerUpdated && addressUpdated && accountUpdated)
            {
                RefreshCustomers();
                MessageBox.Show("Kunden blev opdateret");
            }
            else
            {
                MessageBox.Show("Kunden blev ikke opdateret");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Fejl: {ex.Message}");
            await Console.Out.WriteLineAsync(ex.StackTrace);
        }
    }

    private async void buttonDelete_Click(object sender, EventArgs e)
    {
        if (selectedCustomer == null)
        {
            MessageBox.Show(@"Vælg en kunde");
            return;
        }
        DeleteCustomerData(selectedCustomer);

        // Update the customer with removed data
        var updated = await customerController.Update(selectedCustomer);
        if (updated)
        {
            MessageBox.Show(@"Kundens personlige data er blevet fjernet");
            // Refresh the data grid or perform necessary UI updates
            RefreshCustomers();
        }
        else
        {
            MessageBox.Show(@"Der skete en fejl, kundens personlige data er ikke blevet fjernet");
        }
    }


    private void DeleteCustomerData(Customer customer)
    {
        // Replace personal data with null or empty values
        customer.FirstName = "";
        customer.LastName = "";
        customer.PhoneNo = "";
        customer.AddressID = null;
    }

    private void textboxSearch_TextChanged(object sender, EventArgs e)
    {
        var searchValue = textboxSearch.Text.ToLower();

        var filteredCustomers = customers.Where(c =>
            FuzzyMatch(c.FirstName.ToLower(), searchValue) ||
            FuzzyMatch(c.LastName.ToLower(), searchValue) ||
            FuzzyMatch(c.PhoneNo.ToLower(), searchValue)
        ).ToList();

        customerGrid.DataSource = filteredCustomers;
    }

    private bool FuzzyMatch(string text, string searchTerm)
    {
        if (string.IsNullOrEmpty(searchTerm))
        {
            return true;
        }

        var searchTextIndex = 0;

        foreach (var _ in text.Where(charFromText => searchTerm[searchTextIndex] == charFromText))
        {
            searchTextIndex++;
            if (searchTextIndex == searchTerm.Length)
            {
                return true;
            }
        }

        return false;
    }

    private void sortBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        var sortFilter = sortBox.SelectedIndex;
        if (customerGrid.DataSource is not List<Customer> sortedCustomers)
        {
            MessageBox.Show(@"Der er ingen kunder at sortere");
            return;
        }

        sortedCustomers = sortFilter switch
        {
            0 => sortedCustomers.OrderBy(product => product.FirstName).ToList(),
            1 => sortedCustomers.OrderByDescending(product => product.FirstName).ToList(),
            2 => sortedCustomers.OrderBy(product => product.LastName).ToList(),
            3 => sortedCustomers.OrderByDescending(product => product.LastName).ToList(),
            _ => sortedCustomers
        };
        customerGrid.DataSource = sortedCustomers;
    }

    private void customerGrid_CellDoubleClick(object sender, EventArgs e)
    {
        EditMethod();
    }
}