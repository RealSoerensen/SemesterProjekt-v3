using Client.Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Forms.OrderPanels {
    public partial class OrderDetails : Form {
        private readonly OrderController orderController = new();
        private readonly CustomerController customerController = new();
        private readonly OrderlineController orderlineController = new();
        public OrderDetails(OrdersPanel.OrderViewModel orderViewModel) {
            InitializeComponent();
            labelOrderID.Text = orderViewModel.OrderID.ToString();
            labelDate.Text = orderViewModel.Date.ToString();
            labelOrderPrice.Text = orderViewModel.PriceOfOrder.ToString();
            labelFirstName.Text = orderViewModel.Customer.ToString();

            
            

        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }
    }
}
