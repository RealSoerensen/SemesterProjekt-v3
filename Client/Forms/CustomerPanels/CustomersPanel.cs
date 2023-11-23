using Client.Controllers;
using Client.DAL;
using Models;

namespace Client.Forms.CustomerPanels;

public partial class CustomersPanel : Form {
    private List<Customer> customers = new();
    private Customer? selectedCustomer;
    private readonly CustomerController customerController = new();
    private readonly AddressController addressController = new();

    public CustomersPanel() {
        InitializeComponent();
    }

    private async void CustomersPanel_Load(object sender, EventArgs e) {
        customers = await customerController.GetAll();
        InitializeDataGridView();
    }

    private void InitializeDataGridView() {
        customerGrid.Name = "Customers";
        customerGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        customerGrid.DataSource = customers;
    }

    private async void RefreshCustomers() {
        var firstDisplayedScrollingRowIndex = customerGrid.FirstDisplayedScrollingRowIndex;
        var selectedRowIndex = -1;
        if (customerGrid.SelectedRows.Count > 0) {
            selectedRowIndex = customerGrid.SelectedRows[0].Index;
        }

        customerGrid.DataSource = null;
        customers = await customerController.GetAll();
        customerGrid.DataSource = customers;

        try {
            if (firstDisplayedScrollingRowIndex >= 0) {
                customerGrid.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
            }
            if (selectedRowIndex >= 0 && selectedRowIndex < customerGrid.Rows.Count) {
                customerGrid.Rows[selectedRowIndex].Selected = true;
            }
        } catch (Exception ex) {
            MessageBox.Show("Error while trying to restore grid position and selection: " + ex.Message);
        }
    }

    private void customerGrid_SelectionChanged(object sender, EventArgs e) {
        if (customerGrid.SelectedRows.Count <= 0) return;
        var selectedRow = customerGrid.SelectedRows[0];
        selectedCustomer = selectedRow.DataBoundItem as Customer;
    }

    private async void buttonCreate_Click(object sender, EventArgs e) {
        var createCustomer = new CreateCustomer();
        createCustomer.ShowDialog();
        if (createCustomer.DialogResult != DialogResult.OK) {
            RefreshCustomers();
            return;
        }

        var customer = createCustomer.Customer;
        var address = createCustomer.Address;

        var created = false;
        try {
            address = await addressController.Create(address);
            if (address == null) throw new Exception();
        } catch (Exception) {
            MessageBox.Show(@"Kunne ikke oprette adressen i databasen");
            return;
        }

        customer.AddressID = address.ID;

        try {
            created = created && await customerController.Create(customer) != null;
        } catch (Exception) {
            MessageBox.Show(@"Kunne ikke oprette kunden i databasen");
            return;
        }

        if (!created) {
            MessageBox.Show(@"Kunden blev ikke oprettet");
            return;
        }

        RefreshCustomers();
        MessageBox.Show(@"Kunden blev oprettet");
    }

<<<<<<< Updated upstream
    private async void buttonEdit_Click(object sender, EventArgs e) {
        if (selectedCustomer == null) {
=======
    private async void buttonEdit_Click(object sender, EventArgs e)
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

            var editCustomer = new EditCustomer(selectedCustomer, selectedCustomerAddress);
            editCustomer.ShowDialog();

            if (editCustomer.DialogResult != DialogResult.OK) return;
            var customer = editCustomer.Customer;
            var address = editCustomer.Address;
            Console.WriteLine(customer);
            Console.WriteLine(address);
            bool customerUpdated = await customerController.Update(customer);
            bool addressUpdated = await addressController.Update(address);
            if (customerUpdated && addressUpdated)
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
        }
    }



    private async void buttonDelete_Click(object sender, EventArgs e)
    {
        if (selectedCustomer == null)
        {
>>>>>>> Stashed changes
            MessageBox.Show(@"Vælg en kunde");
            return;
        }

<<<<<<< Updated upstream
        Address? selectedCustomerAddress;
        try {
            selectedCustomerAddress = await addressController.Get((long)selectedCustomer.AddressID!);
        } catch (Exception) {
            MessageBox.Show(@"Kunne ikke hente kundens adresse");
            return;
=======
        // Anonymize the customer's personal data
        DeleteCustomerData(selectedCustomer);

        // Update the customer with anonymized data
        var updated = await customerController.Update(selectedCustomer);
        if (updated)
        {
            MessageBox.Show(@"Kundens personlige data er blevet fjernet");
            // Refresh the data grid or perform necessary UI updates
            RefreshCustomers();
>>>>>>> Stashed changes
        }

        if (selectedCustomerAddress == null) {
            MessageBox.Show(@"Kunne ikke hente kundens adresse");
            return;
        }

        var editCustomer = new EditCustomer(selectedCustomer, selectedCustomerAddress);
        try {
            editCustomer.ShowDialog();
        } catch (Exception) {
            MessageBox.Show(@"Kunne ikke åbne redigeringsvinduet");
            return;
        }

        if (editCustomer.DialogResult != DialogResult.OK) {
            return;
        }

        var customer = editCustomer.Customer;
        var address = editCustomer.Address;

        bool updated;
        try {
            updated = await customerController.Update(customer);
        } catch (Exception) {
            MessageBox.Show(@"Kunne ikke opdatere kunden i databasen");
            return;
        }

        try {
            updated = updated && await addressController.Update(address);
        } catch (Exception) {
            MessageBox.Show(@"Kunne ikke opdatere adressen i databasen");
            return;
        }

        if (!updated) {
            MessageBox.Show(@"Kunden blev ikke opdateret");
            return;
        }
        customerGrid.DataSource = null;
        var index = customers.FindIndex(c => c.ID == selectedCustomer.ID);
        customers[index] = customer;
        customerGrid.DataSource = customers;
        MessageBox.Show(@"Kunden blev opdateret");
    }

    private async void buttonDelete_Click(object sender, EventArgs e) {
        if (selectedCustomer == null) {
            MessageBox.Show(@"Vælg en kunde");
            return;
        }

        var deleted = await customerController.Delete((long)selectedCustomer.ID!);
        if (deleted) {
            customers.Remove(selectedCustomer);
            customerGrid.DataSource = customers;
        } else {
            MessageBox.Show(@"Kunden blev ikke slettet");
        }
    }

<<<<<<< Updated upstream
    private void textboxSearch_TextChanged(object sender, EventArgs e) {
=======
    private void DeleteCustomerData(Customer customer)
    {
        // Replace personal data with null or empty values
        customer.FirstName = "";
        customer.LastName = "";
        customer.Email = "";
        customer.PhoneNo = "";
        customer.Password = "";
        customer.AddressID = null;
    }

    private void textboxSearch_TextChanged(object sender, EventArgs e)
    {
>>>>>>> Stashed changes
        var searchValue = textboxSearch.Text.ToLower();

        var filteredCustomers = customers.Where(c =>
            FuzzyMatch(c.FirstName.ToLower(), searchValue) ||
            FuzzyMatch(c.LastName.ToLower(), searchValue) ||
            FuzzyMatch(c.Email.ToLower(), searchValue) ||
            FuzzyMatch(c.PhoneNo.ToLower(), searchValue)
        ).ToList();

        customerGrid.DataSource = filteredCustomers;
    }

    private bool FuzzyMatch(string text, string searchTerm) {
        if (string.IsNullOrEmpty(searchTerm)) {
            return true;
        }

        var searchTextIndex = 0;

        foreach (var charFromText in text) {
            if (searchTerm[searchTextIndex] == charFromText) {
                searchTextIndex++;
                if (searchTextIndex == searchTerm.Length) {
                    return true;
                }
            }
        }

        return false;
    }

    private void sortBox_SelectedIndexChanged(object sender, EventArgs e) {
        var sortFilter = sortBox.SelectedIndex;
        if (customerGrid.DataSource is not List<Customer> sortedCustomers) {
            MessageBox.Show(@"Der er ingen kunder at sortere");
            return;
        }

        sortedCustomers = sortFilter switch {
            0 => sortedCustomers.OrderBy(product => product.FirstName).ToList(),
            1 => sortedCustomers.OrderByDescending(product => product.FirstName).ToList(),
            2 => sortedCustomers.OrderBy(product => product.LastName).ToList(),
            3 => sortedCustomers.OrderByDescending(product => product.LastName).ToList(),
            4 => sortedCustomers.OrderByDescending(product => product.RegisterDate).ToList(),
            5 => sortedCustomers.OrderBy(product => product.RegisterDate).ToList(),
            _ => sortedCustomers
        };
        customerGrid.DataSource = sortedCustomers;
    }

}