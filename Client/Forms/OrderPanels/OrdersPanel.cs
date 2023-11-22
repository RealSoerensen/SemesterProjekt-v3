using Client.Controllers;
using Models;

namespace Client.Forms.OrderPanels {
    public partial class OrdersPanel : Form {
        private Order? selectedOrder;
        private readonly OrderController orderController = new();
        private readonly CustomerController customerController = new();
        private readonly OrderlineController orderlineController = new();
        public OrdersPanel() {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView() {
            orderGrid.Name = "Orders";
            orderGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Set the DataGridView to full row selection mode
            orderGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Disable multi-select
            orderGrid.MultiSelect = false;
        }

        private void orderGrid_SelectionChanged(object sender, EventArgs e) {
            if (orderGrid.SelectedRows.Count <= 0) return;
            var selectedRow = orderGrid.SelectedRows[0];
            selectedOrder = selectedRow.DataBoundItem as Order;
        }

        private void checkBoxPrice2_CheckedChanged(object sender, EventArgs e) {

        }

        private async void OrdersPanel_Load(object sender, EventArgs e) {
            try {
                await PopulateDataGridViewAsync();
            }
            catch (Exception ex) {
                MessageBox.Show(@"Kunne ikke hente ordre");
                Close();
            }
        }

        private async Task<List<OrderViewModel>> PrepareOrdersData(List<Order> orders) {
            var ordersData = new List<OrderViewModel>();

            foreach (var order in orders) {
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

                if (fetchedCustomer != null) {
                    orderViewModel.Customer = fetchedCustomer.FirstName + " " + fetchedCustomer.LastName;
                }

                if (fetchedOrder != null) {
                    orderViewModel.NumberOfOrderlines = (int)fetchedOrder.ID;
                }

                // decimal with 2 decimals
                var totalPrice = 0m;
                var amountOfProducts = 0;

                if (orderlines != null) {
                    foreach (var orderline in orderlines) {
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

        private async Task PopulateDataGridViewAsync() {
            orderGrid.DataSource = null;
            var orders = await orderController.GetAll();
            var ordersData = await PrepareOrdersData(orders);
            orderGrid.DataSource = ordersData;
        }

        public class OrderViewModel {
            public long OrderID { get; set; }
            public string? Customer { get; set; }
            public DateTime Date { get; set; }
            public int NumberOfOrderlines { get; set; }
            public int NumberOfProducts { get; set; }
            public decimal PriceOfOrder { get; set; }
            // Other properties related to order view model
        }

        private void buttonDetails_Click(object sender, EventArgs e) {

            if (orderGrid.SelectedRows.Count <= 0) return;
            var selectedRow = orderGrid.SelectedRows[0];
            selectedOrder = selectedRow.DataBoundItem as Order;

            if (selectedRow == null) {
                MessageBox.Show("Vælg en ordre");
                return;
            }

            var orderViewModel = new OrderViewModel();
            orderViewModel.OrderID = (long)selectedRow.Cells[0].Value;
            orderViewModel.Customer = (string)selectedRow.Cells[1].Value;
            orderViewModel.Date = (DateTime)selectedRow.Cells[2].Value;
            orderViewModel.PriceOfOrder = (decimal)selectedRow.Cells[5].Value;
            



            var orderDetails = new OrderDetails(orderViewModel);
            orderDetails.ShowDialog();
        }
    }
}
