using Client.Controllers;
using Models;
using System.Globalization;

namespace Client.Forms.ProductPanels;

public partial class EditProduct : Form {
    private readonly Product product;
    private ProductController productController = new();

    public EditProduct(Product product) {
        this.product = product;
        InitializeComponent();
    }

    private void EditProduct_Load(object sender, EventArgs e) {
        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBox.Image = product.ConvertBase64ToImage();
        textBoxProductName.Text = product.Name;
        textBoxBrand.Text = product.Brand;
        textBoxDescription.Text = product.Description;
        textBoxNormalPrice.Text = product.NormalPrice.ToString(CultureInfo.CurrentCulture);
        textBoxPurchasePrice.Text = product.PurchasePrice.ToString(CultureInfo.CurrentCulture);
        textBoxSalesPrice.Text = product.SalePrice.ToString(CultureInfo.CurrentCulture);
        textBoxStock.Text = product.Stock.ToString();

        comboBoxCategory.DataSource = Enum.GetValues(typeof(Category));
        comboBoxCategory.SelectedItem = product.Category;
        comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;

        comboBoxInactive.DataSource = new List<bool> { true, false };
        comboBoxInactive.SelectedItem = product.Inactive;
        comboBoxInactive.DropDownStyle = ComboBoxStyle.DropDownList;
    }


    private void buttonSave_Click(object sender, EventArgs e) {
        if (!ValidateProductInput()) {
            return;
        }

        var result = productController.Update(Product);

        if (result) {
            this.DialogResult = DialogResult.OK;
            this.Close();
        } else {
            this.DialogResult = DialogResult.TryAgain;
        }
    }

    private void buttonChoosePicture_Click(object sender, EventArgs e) {
        using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.Title = "Select a Product Image";

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                Image originalImage = Image.FromFile(openFileDialog.FileName);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                // Now you can use the resized image
                pictureBox.Image = originalImage;
            }
        }
    }

    public Product Product {
        get {
            product.Brand = textBoxBrand.Text;
            product.Description = textBoxDescription.Text;
            product.Name = textBoxProductName.Text;
            product.Image = productController.ConvertImageToBase64(pictureBox.Image);
            product.NormalPrice = decimal.Parse(textBoxNormalPrice.Text);
            product.PurchasePrice = decimal.Parse(textBoxPurchasePrice.Text);
            product.SalePrice = decimal.Parse(textBoxSalesPrice.Text);
            product.Stock = long.Parse(textBoxStock.Text);
            product.Category = (Category)comboBoxCategory.SelectedItem;
            product.Inactive = (bool)comboBoxInactive.SelectedValue;
            return product;
        }
    }

    private bool ValidateProductInput() {
        if (string.IsNullOrWhiteSpace(textBoxProductName.Text)) {
            MessageBox.Show("Produktnavn er påkrævet.");
            return false;
        }
        if (string.IsNullOrWhiteSpace(textBoxBrand.Text)) {
            MessageBox.Show("Mærke er påkrævet.");
            return false;
        }
        if (string.IsNullOrWhiteSpace(textBoxDescription.Text)) {
            MessageBox.Show("Beskrivelse er påkrævet.");
            return false;
        }
        if (!decimal.TryParse(textBoxSalesPrice.Text, out decimal salePrice) || salePrice <= 0) {
            MessageBox.Show("Ugyldig salgspris. Det skal være et positivt tal.");
            return false;
        }
        if (!decimal.TryParse(textBoxPurchasePrice.Text, out decimal purchasePrice) || purchasePrice <= 0) {
            MessageBox.Show("Ugyldig købspris. Det skal være et positivt tal.");
            return false;
        }
        if (!decimal.TryParse(textBoxNormalPrice.Text, out decimal normalPrice) || normalPrice <= 0) {
            MessageBox.Show("Ugyldig normalpris. Det skal være et positivt tal.");
            return false;
        }
        if (!long.TryParse(textBoxStock.Text, out long stock) || stock < 0) {
            MessageBox.Show("Ugyldig lagerantal. Det kan ikke være negativt.");
            return false;
        }

        return true;
    }

    private void removePictureButton_Click(object sender, EventArgs e) {
        product.Image = "";
        pictureBox.Image = null;
    }

    private void buttonCancel_Click(object sender, EventArgs e) {
        this.Close();
    }
}