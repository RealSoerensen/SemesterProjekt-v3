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
using Models;

namespace Client.Forms.ProductPanels {
    public partial class CreateProduct : Form {
        private ProductController productController = new();
        public CreateProduct() {
            InitializeComponent();

            comboBoxCategory.DataSource = Enum.GetValues(typeof(Category));
            comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }

        public Product Product {
            get {
                // Assuming Product constructor parameters: 
                // description, image (as base64), sales price, purchase price, normal price, product name, stock, brand, category
                var imageBase64 = productController.ConvertImageToBase64(pictureBoxImage.Image);
                var salesPrice = decimal.Parse(textBoxSalesPrice.Text);
                var purchasePrice = decimal.Parse(textBoxPurchasePrice.Text);
                var normalPrice = decimal.Parse(textBoxNormalPrice.Text);
                var stock = int.Parse(textBoxStock.Text);
                var categoryIntValue = (int)(Category)Enum.Parse(typeof(Category), comboBoxCategory.Text);

                return new Product(
                    textBoxDescription.Text,
                    imageBase64,
                    salesPrice,
                    purchasePrice,
                    normalPrice,
                    textBoxProductName.Text,
                    stock,
                    textBoxBrand.Text,
                    categoryIntValue
                );
            }
        }

        private void buttonChoosePicture_Click(object sender, EventArgs e) {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Select a Product Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    Image originalImage = Image.FromFile(openFileDialog.FileName);
                    pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;

                    // Now you can use the resized image
                    pictureBoxImage.Image = originalImage;
                }
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e) {
            var product = productController.Create(Product);

            if (product != null) {
                this.DialogResult = DialogResult.OK;
                this.Close();
            } else {
                this.DialogResult = DialogResult.TryAgain;
            }
        }
    }
}
