using Client.Forms.CustomerPanels;
using Client.Forms.ProductPanels;

namespace Client.Forms;

public partial class Main : Form
{
    private readonly ProductsPanel productsPanel = new();
    private readonly CustomersPanel customersPanel = new();

    public Main()
    {
        InitializeComponent();
    }

    private void buttonProducts_Click(object sender, EventArgs e)
    {
        //TEST
        customersPanel.Visible = false;
        productsPanel.TopLevel = false;
        panelMain.Controls.Add(productsPanel);
        productsPanel.BringToFront();
        productsPanel.Show();
    }

    private void buttonCustomers_Click(object sender, EventArgs e)
    {
        productsPanel.Visible = false;
        customersPanel.TopLevel = false;
        panelMain.Controls.Add(customersPanel);
        customersPanel.BringToFront();
        customersPanel.Show();
    }
}