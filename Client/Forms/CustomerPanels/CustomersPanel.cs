using Client.Controllers;
using Client.Forms.CustomerPanels;
using Models;

namespace Client
{
    public partial class CustomersPanel : Form
    {
        private List<Customer> customers = new();
        private Customer? selectedCustomer;
        private readonly CustomerController customerController;

        public CustomersPanel()
        {
            customerController = new CustomerController();
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
                MessageBox.Show("Vælg en søgefilter og indtast en søgeord");
                return;
            }

            var searchFilter = filterBox.SelectedIndex;
            switch (searchFilter)
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

                default:
                    break;
            }
        }

        private void SearchByPhoneNo()
        {
            var phoneNo = textboxSearch.Text;
            var customers = this.customers.Where(customer => customer.PhoneNo.ToLower().Contains(phoneNo.ToLower())).ToList();
            if (customers.Count > 0)
            {
                customerGrid.DataSource = customers;
            }
            else
            {
                MessageBox.Show("Kunden blev ikke fundet");
            }
        }

        private void SearchByEmail()
        {
            var email = textboxSearch.Text;
            var customers = this.customers.Where(customer => customer.Email.ToLower().Contains(email.ToLower())).ToList();
            if (customers.Count > 0)
            {
                customerGrid.DataSource = customers;
            }
            else
            {
                MessageBox.Show("Kunden blev ikke fundet");
            }
        }

        private void SearchByLastName()
        {
            var lastName = textboxSearch.Text;
            var customers = this.customers.Where(customer => customer.LastName.ToLower().Contains(lastName.ToLower())).ToList();
            if (customers.Count > 0)
            {
                customerGrid.DataSource = customers;
            }
            else
            {
                MessageBox.Show("Kunden blev ikke fundet");
            }
        }

        private void SearchByFirstName()
        {
            var firstName = textboxSearch.Text;
            var customers = this.customers.Where(customer => customer.FirstName.ToLower().Contains(firstName.ToLower())).ToList();
            if (customers.Count > 0)
            {
                customerGrid.DataSource = customers;
            }
            else
            {
                MessageBox.Show("Kunden blev ikke fundet");
            }
        }

        private void SearchByID()
        {
            long id = 0;
            try
            {
                id = long.Parse(textboxSearch.Text);
            }
            catch
            {
                MessageBox.Show("ID'et indtastet er ikke et tal");
                return;
            }

            var customer = customers.Single(customer => customer.ID == id);
            if (customer != null)
            {
                customerGrid.DataSource = new List<Customer> { customer };
            }
            else
            {
                MessageBox.Show("Kunden blev ikke fundet");
            }
        }

        private void sortBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sortFilter = sortBox.SelectedIndex;
            List<Customer>? sortedCustomers = customerGrid.DataSource as List<Customer>;
            if (sortedCustomers == null)
            {
                MessageBox.Show("Der er ingen kunder at sortere");
                return;
            }
            switch (sortFilter)
            {
                case 0:
                    sortedCustomers = SortByRegisterDate(sortedCustomers);
                    break;

                case 1:
                    sortedCustomers = SortByRegisterDateDescending(sortedCustomers);
                    break;
            }
            customerGrid.DataSource = sortedCustomers;
        }

        private List<Customer> SortByRegisterDateDescending(List<Customer> customers)
        {
            return customers.OrderByDescending(customer => customer.RegisterDate).ToList();
        }

        private List<Customer> SortByRegisterDate(List<Customer> customers)
        {
            return customers.OrderBy(customer => customer.RegisterDate).ToList();
        }

        private void customerGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Select the whole row on click
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = customerGrid.Rows[e.RowIndex];
                if (row != null)
                {
                    row.Selected = true;
                    selectedCustomer = row.DataBoundItem as Customer;
                }

            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (selectedCustomer == null)
            {
                MessageBox.Show("Vælg en kunde");
                return;
            }

            var editCustomer = new EditCustomer(selectedCustomer);
            editCustomer.ShowDialog();
            if (editCustomer.DialogResult != DialogResult.OK)
            {
                return;
            }

            var customer = editCustomer.Customer;
            if (customer != null)
            {
                bool updated = false;
                try
                {
                    updated = customerController.Update(customer);
                }
                catch (Exception)
                {
                    MessageBox.Show("Kunne ikke opdatere kunden i databasen");
                    return;
                }

                if (!updated)
                {
                    MessageBox.Show("Kunden blev ikke opdateret");
                    return;
                }
                customerGrid.DataSource = null;
                var index = customers.FindIndex(customer => customer.ID == selectedCustomer.ID);
                customers[index] = customer;
                customerGrid.DataSource = customers;
                MessageBox.Show("Kunden blev opdateret");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (selectedCustomer == null)
            {
                MessageBox.Show("Vælg en kunde");
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
                MessageBox.Show("Kunden blev ikke slettet");
            }
        }
    }
}