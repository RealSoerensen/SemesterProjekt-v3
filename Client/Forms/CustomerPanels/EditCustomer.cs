using Models;

namespace Client.Forms.CustomerPanels
{
    public partial class EditCustomer : Form
    {
        private Customer customer;

        public EditCustomer(Customer customer)
        {
            this.customer = customer;
            InitializeComponent();
            SetCustomerInfo();
        }

        private void SetCustomerInfo()
        {
            tbID.Text = customer.ID.ToString();
            tbFirstName.Text = customer.FirstName;
            tbLastName.Text = customer.LastName;
            tbEmail.Text = customer.Email;
            tbPhoneNo.Text = customer.PhoneNo;
            textBox1.Text = customer.RegisterDate.ToString();
        }

        // Add event handlers for saving changes, e.g., when the save button is clicked
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Save the changes
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // Cancel the changes
            DialogResult = DialogResult.Cancel;
        }

        public Customer Customer
        {
            get
            {
                // Update the customer object with the edited values
                customer.FirstName = tbFirstName.Text;
                customer.LastName = tbLastName.Text;
                customer.Email = tbEmail.Text;
                customer.PhoneNo = tbPhoneNo.Text;
                return customer;
            }
        }
    }
}