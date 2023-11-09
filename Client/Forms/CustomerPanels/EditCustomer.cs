using Client.Controllers;
using Models;

namespace Client.Forms.CustomerPanels
{
    public partial class EditCustomer : Form
    {
        private Customer customer;
        private AddressController addressController = new();
        private Address? address;

        public EditCustomer(Customer customer)
        {
            this.customer = customer;
            try
            {
                var addressId = customer.AddressID!;
                address = addressController.Get((long)addressId);
            }
            catch (Exception)
            {
                MessageBox.Show("Kunne ikke hente adresse");
                Close();
            }
            if (address == null)
            {
                MessageBox.Show("Kunne ikke hente adresse");
                Close();
            }
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
            tbDateCreated.Text = customer.RegisterDate.ToString();
            tbHouseNumber.Text = address!.HouseNumber.ToString();
            tbStreet.Text = address.Street;
            tbCity.Text = address.City;
            tbZip.Text = address.Zip;
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

        public Address Address
        {
            get
            {
                // Update the address object with the edited values
                address!.HouseNumber = tbHouseNumber.Text;
                address.Street = tbStreet.Text;
                address.City = tbCity.Text;
                address.Zip = tbZip.Text;
                return address;
            }
        }
    }
}