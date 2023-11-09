using Client.Controllers;
using Models;

namespace Client {
    public partial class CustomersPanel : Form {
        private List<Customer> customers = new();
        private readonly CustomerController customerController;

        public CustomersPanel() {
            customerController = new CustomerController();
            Load += CustomersPanel_Load;
            InitializeComponent();
        }

        private void CustomersPanel_Load(object sender, EventArgs e) {
            Console.WriteLine("Getting customers");
            customers = customerController.GetAll();
            InitializeDataGridView();
        }

        private void InitializeDataGridView() {
            customerGrid.Name = "Customers";
            customerGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            customerGrid.DataSource = customers;
        }

        private void buttonSearch_Click(object sender, EventArgs e) {
            if (filterBox == null || textboxSearch == null) {
                MessageBox.Show("Vælg en søgefilter og indtast en søgeord");
                return;
            }

            var searchFilter = filterBox.Text;
            switch (searchFilter) {
                case "ID":
                    SearchByID();
                    break;

                case "Fornavn":
                    SearchByFirstName();
                    break;

                case "Efternavn":
                    SearchByLastName();
                    break;

                case "Email":
                    SearchByEmail();
                    break;

                case "Tlf. nummer":
                    SearchByPhoneNo();
                    break;

                default:
                    break;
            }
        }

        private void SearchByPhoneNo() {
            var phoneNo = textboxSearch.Text;
            var customers = this.customers.Where(customer => customer.PhoneNo.ToLower().Contains(phoneNo.ToLower())).ToList();
            if (customers.Count > 0) {
                customerGrid.DataSource = customers;
            }
            else {
                MessageBox.Show("Kunden blev ikke fundet");
            }
        }

        private void SearchByEmail() {
            var email = textboxSearch.Text;
            var customers = this.customers.Where(customer => customer.Email.ToLower().Contains(email.ToLower())).ToList();
            if (customers.Count > 0) {
                customerGrid.DataSource = customers;
            }
            else {
                MessageBox.Show("Kunden blev ikke fundet");
            }
        }

        private void SearchByLastName() {
            var lastName = textboxSearch.Text;
            var customers = this.customers.Where(customer => customer.LastName.ToLower().Contains(lastName.ToLower())).ToList();
            if (customers.Count > 0) {
                customerGrid.DataSource = customers;
            }
            else {
                MessageBox.Show("Kunden blev ikke fundet");
            }
        }

        private void SearchByFirstName() {
            var firstName = textboxSearch.Text;
            var customers = this.customers.Where(customer => customer.FirstName.ToLower().Contains(firstName.ToLower())).ToList();
            if (customers.Count > 0) {
                customerGrid.DataSource = customers;
            }
            else {
                MessageBox.Show("Kunden blev ikke fundet");
            }
        }

        private void SearchByID() {
            long id = 0;
            try {
                id = long.Parse(textboxSearch.Text);
            }
            catch {
                MessageBox.Show("ID'et indtastet er ikke et tal");
                return;
            }

            var customer = customers.Single(customer => customer.ID == id);
            if (customer != null) {
                customerGrid.DataSource = new List<Customer> { customer };
            }
            else {
                MessageBox.Show("Kunden blev ikke fundet");
            }
        }

        private void sortBox_SelectedIndexChanged(object sender, EventArgs e) {
            var customers = customerGrid.DataSource as List<Customer>;
            if (customers == null) {
                return;
            }
        }
    }
}