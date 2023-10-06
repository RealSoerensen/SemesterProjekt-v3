using Client.Controllers;

namespace Client;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void RefreshTabWindow()
    {
        var customerController = new CustomerController();
        var customers = customerController.GetAll();
        if (customers == null) return;
        var customerList = customers.Select(customer => customer.FirstName + " " +customer.LastName).ToList();
        listBox1.DataSource = customerList;
    }

    private void refreshBtn_Click(object sender, EventArgs e)
    {
        RefreshTabWindow();
    }
}