using Client.Controllers;
using Models;

namespace Client.Forms.CustomerPanels;

public partial class CustomersPanel : Form
{
    private List<Customer> customers = new();
    private Customer? selectedCustomer;
    private readonly CustomerController customerController = new();
    private readonly AddressController addressController = new();

    public CustomersPanel()
    {
        InitializeComponent();
    }

    private void CustomersPanel_Load(object sender, EventArgs e)
    {
        customers = customerController.GetAll();
        InitializeDataGridView();
    }

    private void InitializeDataGridView()
    {
        customerGrid.Name = "Customers";
        customerGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        customerGrid.DataSource = customers;
    }

    private void buttonSearch_Click(object sender, EventArgs e)
    {
        if (filterBox == null || textboxSearch == null)
        {
            MessageBox.Show(@"Vælg en søgefilter og indtast en søgeord");
            return;
        }

        switch (filterBox.SelectedIndex)
        {
            case 0:
                SearchByID();
                break;

            case 1:
                SearchByFirstName();
                break;

            case 2:
                SearchByLastName();
                break;

            case 3:
                SearchByEmail();
                break;

            case 4:
                SearchByPhoneNo();
                break;
        }
    }

    private void SearchByPhoneNo()
    {
        var phoneNo = textboxSearch.Text;
        var sortedCustomers = this.customers.Where(customer => customer.PhoneNo.ToLower().Contains(phoneNo.ToLower())).ToList();
        if (sortedCustomers.Count > 0)
        {
            customerGrid.DataSource = sortedCustomers;
        }
        else
        {
            MessageBox.Show(@"Kunden blev ikke fundet");
        }
    }

    private void SearchByEmail()
    {
        var email = textboxSearch.Text;
        var sortedCustomers = this.customers.Where(customer => customer.Email.ToLower().Contains(email.ToLower())).ToList();
        if (sortedCustomers.Count > 0)
        {
            customerGrid.DataSource = sortedCustomers;
        }
        else
        {
            MessageBox.Show(@"Kunden blev ikke fundet");
        }
    }

    private void SearchByLastName()
    {
        var lastName = textboxSearch.Text;
        var sortedCustomers = this.customers.Where(c => c.LastName.ToLower().Contains(lastName.ToLower())).ToList();
        if (sortedCustomers.Count > 0)
        {
            customerGrid.DataSource = sortedCustomers;
        }
        else
        {
            MessageBox.Show(@"Kunden blev ikke fundet");
        }
    }

    private void SearchByFirstName()
    {
        var firstName = textboxSearch.Text;
        var sortedCustomers = this.customers.Where(c => c.FirstName.ToLower().Contains(firstName.ToLower())).ToList();
        if (sortedCustomers.Count > 0)
        {
            customerGrid.DataSource = sortedCustomers;
        }
        else
        {
            MessageBox.Show(@"Kunden blev ikke fundet");
        }
    }

    private void SearchByID()
    {
        long id;
        try
        {
            id = long.Parse(textboxSearch.Text);
        }
        catch
        {
            MessageBox.Show(@"ID'et indtastet er ikke et tal");
            return;
        }

        var customer = customers.Single(customer => customer.ID == id);
        customerGrid.DataSource = new List<Customer> { customer };
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
            0 => SortByRegisterDate(sortedCustomers),
            1 => SortByRegisterDateDescending(sortedCustomers),
            _ => sortedCustomers
        };
        customerGrid.DataSource = sortedCustomers;
    }

    private List<Customer> SortByRegisterDateDescending(IEnumerable<Customer> customersToSort)
    {
        return customersToSort.OrderByDescending(customer => customer.RegisterDate).ToList();
    }

    private List<Customer> SortByRegisterDate(IEnumerable<Customer> customersToSort)
    {
        return customersToSort.OrderBy(customer => customer.RegisterDate).ToList();
    }

    private void customerGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        // Select the whole row on click
        if (e.RowIndex < 0) return;
        var row = customerGrid.Rows[e.RowIndex];
        row.Selected = true;
        selectedCustomer = row.DataBoundItem as Customer;
    }

    private void buttonCreate_Click(object sender, EventArgs e)
    {
        var createCustomer = new CreateCustomer();
        createCustomer.ShowDialog();
        if (createCustomer.DialogResult != DialogResult.OK)
        {
            return;
        }

        var customer = createCustomer.Customer;
        var address = createCustomer.Address;

        var created = false;
        try
        {
            address = addressController.Create(address);
            if (address == null) throw new Exception();
        }
        catch (Exception)
        {
            MessageBox.Show(@"Kunne ikke oprette adressen i databasen");
            return;
        }

        customer.AddressID = address.ID;

        try
        {
            created = created && customerController.Create(customer) != null;
        }
        catch (Exception)
        {
            MessageBox.Show(@"Kunne ikke oprette kunden i databasen");
            return;
        }

        if (!created)
        {
            MessageBox.Show(@"Kunden blev ikke oprettet");
            return;
        }

        customers.Add(customer);
        customerGrid.DataSource = null;
        customerGrid.DataSource = customers;
        MessageBox.Show(@"Kunden blev oprettet");
    }

    private void buttonEdit_Click(object sender, EventArgs e)
    {
        if (selectedCustomer == null)
        {
            MessageBox.Show(@"Vælg en kunde");
            return;
        }

        var editCustomer = new EditCustomer(selectedCustomer);
        editCustomer.ShowDialog();
        if (editCustomer.DialogResult != DialogResult.OK)
        {
            return;
        }

        var customer = editCustomer.Customer;
        var address = editCustomer.Address;

        bool updated;
        try
        {
            updated = customerController.Update(customer);
        }
        catch (Exception)
        {
            MessageBox.Show(@"Kunne ikke opdatere kunden i databasen");
            return;
        }

        try
        {
            updated = updated && addressController.Update(address);
        }
        catch (Exception)
        {
            MessageBox.Show(@"Kunne ikke opdatere adressen i databasen");
            return;
        }

        if (!updated)
        {
            MessageBox.Show(@"Kunden blev ikke opdateret");
            return;
        }
        customerGrid.DataSource = null;
        var index = customers.FindIndex(c => c.ID == selectedCustomer.ID);
        customers[index] = customer;
        customerGrid.DataSource = customers;
        MessageBox.Show(@"Kunden blev opdateret");
    }

    private void buttonDelete_Click(object sender, EventArgs e)
    {
        if (selectedCustomer == null)
        {
            MessageBox.Show(@"Vælg en kunde");
            return;
        }

        var deleted = customerController.Delete((long)selectedCustomer.ID!);
        if (deleted)
        {
            customers.Remove(selectedCustomer);
            customerGrid.DataSource = customers;
        }
        else
        {
            MessageBox.Show(@"Kunden blev ikke slettet");
        }
    }
}