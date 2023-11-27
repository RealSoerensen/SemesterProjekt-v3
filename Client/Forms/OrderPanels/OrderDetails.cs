using Client.Controllers;
using Models;

namespace Client.Forms.OrderPanels
{
    public partial class OrderDetails : Form
    {
        private readonly ProductController productController = new();
        private readonly AddressController addressController = new();
        private readonly List<Product?> products = new();
        public OrderDetails(OrderViewModel orderViewModel)
        {
            InitializeComponent();
            labelOrderID.Text = orderViewModel.OrderID.ToString();
            labelDate.Text = orderViewModel.Date.ToString();
            labelOrderPrice.Text = orderViewModel.PriceOfOrder.ToString();

            labelFirstName.Text = orderViewModel.Customer.FirstName;
            labelLastName.Text = orderViewModel.Customer.LastName;
            labelCustomerID.Text = orderViewModel.Customer.ID.ToString();
            GetAddressAsync((long)orderViewModel.Customer.AddressID);
            GetProductsAsync(orderViewModel.Orderlines);
        }

        private void ProductGridViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private async void GetAddressAsync(long addressID)
        {
            var address = await addressController.Get(addressID);
            labelAddress.Text = address.Street + " " + address.HouseNumber;
            labelCity.Text = address.City;
        }

        private async void GetProductsAsync(List<Orderline> orderlines)
        {
            foreach (var orderline in orderlines)
            {
                var product = await productController.Get(orderline.ProductID);
                products.Add(product);
            }
            productGridView.DataSource = products;
        }
    }
}
