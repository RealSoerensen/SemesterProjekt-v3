using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Controllers;
using Client.DAL;
using Models;

namespace Client.Forms.OrderPanels {
    public partial class OrdersPanel : Form {
        private List<Order> orders = new();
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
            orderGrid.DataSource = orders;

            // Set the DataGridView to full row selection mode
            orderGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Disable multi-select
            orderGrid.MultiSelect = false;
        }

        private void orderGrid_SelectionChanged(object sender, EventArgs e) {
            if (orderGrid.SelectedRows.Count > 0) {
                var selectedRow = orderGrid.SelectedRows[0];
                selectedOrder = selectedRow.DataBoundItem as Order;
            }
        }

        private void RefreshOrders() {
            
        }

        private void checkBoxPrice2_CheckedChanged(object sender, EventArgs e) {

        }

        private void OrdersPanel_Load_1(object sender, EventArgs e) {
            try {
                orders = orderController.GetAll();

                PopulateDataGridView();

            } catch (Exception ex) {
                MessageBox.Show(@"Kunne ikke hente ordre");
                Console.WriteLine(ex);
                Close();
            }
        }

        private void PopulateDataGridView() {
            orderGrid.DataSource = null;
            foreach (var order in orders) {
                int rowIndex = orderGrid.Rows.Add();
                orderGrid.Rows[rowIndex].Cells["OrderID"].Value = order.ID;
                orderGrid.Rows[rowIndex].Cells["Date"].Value = order.Date;

                Customer customerOnOrder = customerController.Get(order.CustomerID);

                if (customerOnOrder != null) {
                    orderGrid.Rows[rowIndex].Cells["Customer"].Value = customerOnOrder.FirstName + " " + customerOnOrder.LastName;
                }

                var orderlines = orderlineController.Get((long)order.ID);

                orderGrid.Rows[rowIndex].Cells["NumberOfOrderlines"].Value = orderlines.Count;

                var amountOfProducts = 0;
                decimal totalPrice = 0;
                foreach (var orderline in orderlines) {
                    amountOfProducts += orderline.Quantity;
                    totalPrice += orderline.Quantity * orderline.PriceAtTimeOfOrder;
                }

                orderGrid.Rows[rowIndex].Cells["NumberOfProducts"].Value = amountOfProducts;
                orderGrid.Rows[rowIndex].Cells["PriceOfOrder"].Value = totalPrice;
            }
        }
    }
}
