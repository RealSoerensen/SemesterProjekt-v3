﻿using Client.Controllers;
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
                    totalPrice += orderline.PriceAtTimeOfOrder;
                    amountOfProducts += orderline.Quantity;
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
