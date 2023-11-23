using Client.Controllers;

namespace Client.Forms.OrderPanels
{
    public partial class OrderDetails : Form
    {
        private readonly OrderController orderController = new();
        private readonly CustomerController customerController = new();
        private readonly OrderlineController orderlineController = new();
        private readonly ProductController productController = new();
        private readonly AddressController addressController = new();
        public OrderDetails(OrderViewModel orderViewModel)
        {
            InitializeComponent();
            labelOrderID.Text = orderViewModel.OrderID.ToString();
            labelDate.Text = orderViewModel.Date.ToString();
            labelOrderPrice.Text = orderViewModel.PriceOfOrder.ToString();

            if (orderViewModel.Customer != null)
            {
                labelFirstName.Text = orderViewModel.Customer.FirstName;
                labelLastName.Text = orderViewModel.Customer.LastName;
                labelCustomerID.Text = orderViewModel.Customer.ID.ToString();
                GetAddressAsync((long)orderViewModel.Customer.AddressID);
            }

            dataGridView1.DataSource = orderViewModel.Orderlines;
            dataGridView1.Columns["OrderID"].Visible = false;
            dataGridView1.Columns.Remove("Quantity");
            dataGridView1.Columns.Remove("PriceAtTimeOfOrder");
            dataGridView1.Columns.Add("ProductName", "Product Name");

            dataGridView1.ReadOnly = true;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private async void GetAddressAsync(long addressID)
        {
            var address = await addressController.Get(addressID);
            labelAddress.Text = address.Street + " " + address.HouseNumber;
            labelCity.Text = address.City;
        }

    }
}
