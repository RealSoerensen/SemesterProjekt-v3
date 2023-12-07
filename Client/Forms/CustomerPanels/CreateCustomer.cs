using Client.Controllers;
using Models;

namespace Client.Forms.CustomerPanels;

public partial class CreateCustomer : Form
{
    public CreateCustomer()
    {
        InitializeComponent();
    }

    private async void btnCreate_Click(object sender, EventArgs e)
    {
        // Get customer and address from the form
        var userAccount = UserAccount;
        var customer = Customer;
        var address = Address;

        if (!IsCustomerValid(customer) ||
            !IsAddressValid(address) ||
            !IsEmailValid(userAccount.Email) ||
            !IsPasswordValid(userAccount.Password, tbPasswordConfirm.Text))
        {
            MessageBox.Show(@"Please check your input. Ensure all fields are correctly filled.");
            return;
        }


        // Create instances of CustomerController and AddressDA
        var customerController = new CustomerController();

        // Create the customer
        var createdCustomer = await customerController.Create(customer, address);
        if (createdCustomer != null)
        {
            MessageBox.Show(@"Customer and Address created successfully!");
            Close();
            return;
        }

        MessageBox.Show(@"Failed to create Customer and Address.");
        DialogResult = DialogResult.Cancel;
    }

    private bool IsCustomerValid(Customer customer)
    {
        // Add validation logic for Customer
        return !string.IsNullOrWhiteSpace(customer.FirstName) &&
               !string.IsNullOrWhiteSpace(customer.LastName) &&
               !string.IsNullOrWhiteSpace(customer.PhoneNo);
    }

    private bool IsAddressValid(Address address)
    {
        // Add validation logic for Address
        return !string.IsNullOrWhiteSpace(address.Street) &&
               !string.IsNullOrWhiteSpace(address.City) &&
               !string.IsNullOrWhiteSpace(address.Zip) &&
               !string.IsNullOrWhiteSpace(address.HouseNumber);
    }
    private bool IsPasswordValid(string password, string confirmPassword)
    {
        // Check if the password is not empty and matches the confirm password
        return !string.IsNullOrWhiteSpace(password) && password == confirmPassword;
    }

    private bool IsEmailValid(string email)
    {
        // Simple email validation logic
        try
        {
            var Eaddr = new System.Net.Mail.MailAddress(email);
            return Eaddr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }

    public Customer Customer =>
        // Update the customer object with the edited values
        new(tbFirstName.Text, tbLastName.Text, tbPhonenumber.Text);

    public Address Address =>
        // Update the address object with the edited values
        new(tbStreet.Text, tbCity.Text, tbZip.Text, tbHouseNumber.Text);
    public UserAccount UserAccount =>
        // Update the user account object with the edited values
        new(tbEmail.Text, tbPassword.Text);
}