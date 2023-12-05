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
            var customers = await customerController.GetAll();
            var orderlines = await orderlineController.GetAll();

            foreach (var order in orders)
            {
                var orderViewModel = new OrderViewModel
                {
                    OrderID = order.ID,
                    Date = order.Date
                };

                var fetchedCustomer = customers.FirstOrDefault(c => c.ID == order.CustomerID);
                var fetchedOrderlines = orderlines.Where(o => o.OrderID == order.ID).ToList();

                if (fetchedCustomer != null)
                {
                    orderViewModel.Customer = fetchedCustomer;
                }

                // decimal with 2 decimals
                var totalPrice = 0m;
                var amountOfProducts = 0;

                orderViewModel.Orderlines = fetchedOrderlines;
                orderViewModel.NumberOfOrderlines = fetchedOrderlines.Count;
                foreach (var orderline in fetchedOrderlines)
                {
                    totalPrice += orderline.PriceAtTimeOfOrder * orderline.Quantity;
                    amountOfProducts += orderline.Quantity;
                }

                orderViewModel.NumberOfProducts = amountOfProducts;
                orderViewModel.PriceOfOrder = decimal.Round(totalPrice, 2, MidpointRounding.AwayFromZero);

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

        private async void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var checkBoxesToPriceRanges = new Dictionary<CheckBox, (decimal, decimal)>
            {
                { checkBoxPrice1, (0, 500) },
                { checkBoxPrice2, (500, 1000) },
                { checkBoxPrice3, (1000, 1500) },
                { checkBoxPrice4, (1500, 2000) },
                { checkBoxPrice5, (2000, 2500) },
                { checkBoxPrice6, (2500, 3000) },
                { checkBox1, (3000, 3500) },
                { checkBox2, (3500, decimal.MaxValue) }
            };

            var senderCheckBox = sender as CheckBox;
            if (checkBoxesToPriceRanges.ContainsKey(senderCheckBox))
            {
                if (senderCheckBox.Checked)
                {
                    foreach (var checkBox in checkBoxesToPriceRanges.Keys.Where(checkBox => checkBox != senderCheckBox))
                    {
                        checkBox.Checked = false;
                    }
                }
            }

            var selectedPriceRange = checkBoxesToPriceRanges
                .Where(kv => kv.Key.Checked)
                .Select(kv => kv.Value)
                .FirstOrDefault(); // Take the first selected price range

            orderGrid.DataSource = null;
            var orders = await orderController.GetAll();
            var ordersData = await PrepareOrdersData(orders);

            List<OrderViewModel> filteredOrders = new List<OrderViewModel>(ordersData);

            // Apply price range filter if any price range is selected.
            if (selectedPriceRange != default)
            {
                filteredOrders = filteredOrders
                    .Where(p => p.PriceOfOrder >= selectedPriceRange.Item1 && p.PriceOfOrder <= selectedPriceRange.Item2)
                    .ToList();
            }

            orderGrid.DataSource = filteredOrders;
        }

        private bool FuzzyMatch(string text, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return true;
            }

            var searchTextIndex = 0;

            foreach (var _ in text.Where(charFromText => searchTerm[searchTextIndex] == charFromText))
            {
                searchTextIndex++;
                if (searchTextIndex == searchTerm.Length)
                {
                    return true;
                }
            }

            return false;
        }

        private async void textBoxSearchbar_TextChanged_1(object sender, EventArgs e)
        {
            orderGrid.DataSource = null;
            var orders = await orderController.GetAll();
            var ordersData = await PrepareOrdersData(orders);

            var searchValue = textBoxSearchbar.Text.ToLower();

            var filteredOrders = string.IsNullOrWhiteSpace(searchValue)
                ? ordersData // If search value is empty, don't filter, include all orders
                : ordersData.Where(p => p.Customer != null &&
                                        FuzzyMatch(p.Customer.FirstName.ToLower() + " " + p.Customer.LastName.ToLower(), searchValue)).ToList();

            orderGrid.DataSource = filteredOrders;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sortFilter = comboBox1.SelectedIndex;
            if (orderGrid.DataSource is not List<OrderViewModel> sortedOrders)
            {
                MessageBox.Show(@"Der er ingen ordre at sortere");
                return;
            }

            sortedOrders = sortFilter switch
            {
                0 => sortedOrders.OrderBy(order => order.Date).ToList(),
                1 => sortedOrders.OrderByDescending(order => order.Date).ToList(),
                2 => sortedOrders.OrderByDescending(order => order.NumberOfOrderlines).ToList(),
                3 => sortedOrders.OrderBy(order => order.NumberOfOrderlines).ToList(),
                4 => sortedOrders.OrderByDescending(order => order.NumberOfProducts).ToList(),
                5 => sortedOrders.OrderBy(order => order.NumberOfProducts).ToList(),
                6 => sortedOrders.OrderByDescending(order => order.PriceOfOrder).ToList(),
                7 => sortedOrders.OrderBy(order => order.PriceOfOrder).ToList(),
                _ => sortedOrders
            };
            orderGrid.DataSource = sortedOrders;
        }

        private void orderGrid_CellDoubleClick(object sender, EventArgs e)
        {
            if (selectedOrder == null) return;
            var orderDetails = new OrderDetails(selectedOrder);
            orderDetails.ShowDialog();
        }
    }
}
