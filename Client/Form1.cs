using Client.Controllers;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RefreshTabWindow();
        }

        private void RefreshTabWindow()
        {
            var customerController = new CustomerController();
            var customers = customerController.GetAll();
            if (customers == null) return;
            listBox1.Items.Clear();
            foreach (var customer in customers)
            {
                string customerString = customer.Id + " " + customer.FirstName + " " + customer.LastName;
                listBox1.Items.Add(customerString);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshTabWindow();
        }
    }
}