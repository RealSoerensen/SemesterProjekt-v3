using Client.Controllers;

namespace Client.Forms.OrderPanels
{
    public partial class OrderDetails : Form
    {
        private readonly OrderController orderController = new();
        private readonly CustomerController customerController = new();
        private readonly OrderlineController orderlineController = new();
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
            }

            dataGridView1.DataSource = orderViewModel.Orderlines;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
