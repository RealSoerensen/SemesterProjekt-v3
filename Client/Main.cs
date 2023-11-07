namespace Client {
    public partial class Main : Form {
        ProductsPanel productsPanel = new ProductsPanel();
        CustomersPanel customersPanel = new CustomersPanel();
        public Main() {
            InitializeComponent();
        }

        private void buttonProducts_Click(object sender, EventArgs e) {

            //TEST
            customersPanel.Visible = false;
            productsPanel.TopLevel = false;
            panelMain.Controls.Add(productsPanel);
            productsPanel.BringToFront();
            productsPanel.Show();
        }

        private void buttonCustomers_Click(object sender, EventArgs e) {

            productsPanel.Visible = false;
            customersPanel.TopLevel = false;
            panelMain.Controls.Add(customersPanel);
            customersPanel.BringToFront();
            customersPanel.Show();
        }
    }
}