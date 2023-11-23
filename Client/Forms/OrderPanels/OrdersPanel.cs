using Client.Controllers;
using Models;

namespace Client.Forms.OrderPanels
{
    public partial class OrdersPanel : Form
    {
        private OrderViewModel? selectedOrder;
        private readonly OrderController orderController = new();
        private readonly CustomerController customerController = new();
        private readonly OrderlineController orderlineController = new();
        public OrdersPanel()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            orderGrid.Name = "Orders";
            orderGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Set the DataGridView to full row selection mode
            orderGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Disable multi-select
            orderGrid.MultiSelect = false;
        }

        private void orderGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (orderGrid.SelectedRows.Count <= 0) return;
            var selectedRow = orderGrid.SelectedRows[0];
            selectedOrder = selectedRow.DataBoundItem as OrderViewModel;
        }

        private void checkBoxPrice2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private async void OrdersPanel_Load(object sender, EventArgs e)
        {
            try
            {
                await PopulateDataGridViewAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show(@"Kunne ikke hente ordre");
                Close();
            }
        }

        private async Task<List<OrderViewModel>> PrepareOrdersData(List<Order> orders)
        {
            var ordersData = new List<OrderViewModel>();

            foreach (var order in orders)
            {
                var orderViewModel = new OrderViewModel
                {
                    OrderID = (long)order.ID,
                    Date = order.Date

                };

                var customerTask = customerController.Get(order.CustomerID);
                var orderTask = orderController.Get(order.ID);
                var orderLinesTask = orderlineController.Get(order.ID);

                await Task.WhenAll(customerTask, orderTask, orderLinesTask);

                var fetchedCustomer = await customerTask;
                var fetchedOrder = await orderTask;
                var orderlines = await orderLinesTask;

                if (fetchedCustomer != null)
                {
                    orderViewModel.Customer = fetchedCustomer;
                }

                if (fetchedOrder != null)
                {
                    orderViewModel.NumberOfOrderlines = orderlines.Count;
                }

                if (orderlines != null)
                {
                    orderViewModel.Orderlines = orderlines;
                }

                // decimal with 2 decimals
                var totalPrice = 0m;
                var amountOfProducts = 0;

                if (orderlines != null)
                {
                    foreach (var orderline in orderlines)
                    {
                        totalPrice += orderline.PriceAtTimeOfOrder;
                        amountOfProducts += orderline.Quantity;
                    }
                }

                orderViewModel.NumberOfProducts = amountOfProducts;
                orderViewModel.PriceOfOrder = totalPrice;
                // Populate other properties similarly

                ordersData.Add(orderViewModel);
            }

            return ordersData;
        }

        private async Task PopulateDataGridViewAsync()
        {
            orderGrid.DataSource = null;
            var orders = await orderController.GetAll();
            var ordersData = await PrepareOrdersData(orders);
            orderGrid.DataSource = ordersData;
        }

        public class OrderViewModel
        {
            public long OrderID { get; set; }
            public Customer? Customer { get; set; }
            public DateTime Date { get; set; }
            public int NumberOfOrderlines { get; set; }
            public int NumberOfProducts { get; set; }
            public decimal PriceOfOrder { get; set; }
            // Other properties related to order view model
            public List<Orderline> Orderlines { get; set; }

        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {

            if (selectedOrder == null)
            {
                MessageBox.Show("Vælg en ordre");
                return;
            }


            var orderDetails = new OrderDetails(selectedOrder);
            orderDetails.ShowDialog();
        }
    }
}
