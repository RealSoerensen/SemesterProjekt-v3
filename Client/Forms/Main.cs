using Client.Forms.CustomerPanels;
using Client.Forms.ProductPanels;
using Client.Forms.OrderPanels;

namespace Client.Forms;

public partial class Main : Form {
    private readonly ProductsPanel productsPanel = new();
    private readonly CustomersPanel customersPanel = new();
    private readonly OrdersPanel ordersPanel = new();

    public Main() {
        InitializeComponent();
        this.Load += Main_Load;
    }

    private void Main_Load(object sender, EventArgs e) {
        buttonProducts_Click(this, EventArgs.Empty);
    }

    private void buttonProducts_Click(object sender, EventArgs e) {
        //TEST
        ordersPanel.Visible = false;
        customersPanel.Visible = false;
        productsPanel.TopLevel = false;
        panelMain.Controls.Add(productsPanel);
        productsPanel.BringToFront();
        productsPanel.Show();
    }

    private void buttonCustomers_Click(object sender, EventArgs e) {
        ordersPanel.Visible = false;
        productsPanel.Visible = false;
        customersPanel.TopLevel = false;
        panelMain.Controls.Add(customersPanel);
        customersPanel.BringToFront();
        customersPanel.Show();
    }

    private void buttonOrders_Click(object sender, EventArgs e) {
        customersPanel.Visible = false;
        productsPanel.Visible = false;
        ordersPanel.TopLevel = false;
        panelMain.Controls.Add(ordersPanel);
        ordersPanel.BringToFront();
        ordersPanel.Show();
    }
}