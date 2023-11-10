using Models;

namespace Client.Forms.CustomerPanels;

public partial class CreateCustomer : Form
{
    private Customer? customer;
    private Address? address;

    public CreateCustomer()
    {
        InitializeComponent();
    }

    private void btnCreate_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }

    public Customer Customer
    {
        get
        {
            // Update the customer object with the edited values
            customer!.FirstName = tbFirstName.Text;
            customer.LastName = tbLastName.Text;
            customer.Email = tbEmail.Text;
            customer.PhoneNo = tbPhonenumber.Text;
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