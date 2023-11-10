using Models;

namespace Client.Forms.CustomerPanels;

public partial class CreateCustomer : Form
{
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

    public Customer Customer =>
        // Update the customer object with the edited values
        new(tbFirstName.Text, tbLastName.Text, tbEmail.Text, tbPhonenumber.Text, tbPassword.Text);

    public Address Address =>
        // Update the address object with the edited values
        new(tbStreet.Text, tbCity.Text, tbZip.Text, tbHouseNumber.Text);
}