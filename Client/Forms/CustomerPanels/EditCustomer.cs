using Client.Controllers;
using Models;

namespace Client.Forms.CustomerPanels;

public partial class EditCustomer : Form
{
    private readonly Customer customer;
    private readonly Address address;
    private readonly UserAccount account;
    private readonly CustomerController customerController = new();
    private readonly AddressController addressController = new();
    private readonly UserAccountController accountController = new();

    public EditCustomer(Customer customer, Address address, UserAccount account)
    {
        this.customer = customer;
        this.address = address;
        this.account = account;
        InitializeComponent();
        SetCustomerInfo();
    }

    private void SetCustomerInfo()
    {
        tbID.Text = customer.ID.ToString();
        tbFirstName.Text = customer.FirstName;
        tbLastName.Text = customer.LastName;
        tbPhoneNo.Text = customer.PhoneNo;
        tbEmail.Text = account.Email;
        tbHouseNumber.Text = address!.HouseNumber;
        tbStreet.Text = address.Street;
        tbCity.Text = address.City;
        tbZip.Text = address.Zip;
    }

    // Add event handlers for saving changes, e.g., when the save button is clicked
    private async void saveButton_Click(object sender, EventArgs e)
    {
        var customerUpdated = await customerController.Update(Customer);
        var addressUpdated = await addressController.Update(Address);
        var accountUpdated = await accountController.Update(account);

        if (customerUpdated && addressUpdated && accountUpdated)
        {
            // Save the changes
            DialogResult = DialogResult.OK;
        }
        else
        {
            DialogResult = DialogResult.TryAgain;
        }
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

    public UserAccount UserAccount
    {
        get
        {
            // Update the user account object with the edited values
            account.Email = tbEmail.Text;
            return account;
        }
    }
}