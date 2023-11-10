using Models;
using System.Globalization;

namespace Client.Forms.ProductPanels;

public partial class EditProduct : Form
{
    private readonly Product product;

    public EditProduct(Product product)
    {
        this.product = product;
        InitializeComponent();
    }

    private void EditProduct_Load(object sender, EventArgs e)
    {
        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBox.Image = product.ConvertBase64ToImage();
        textBoxID.Text = product.ID.ToString();
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
    }

    public Product Product
    {
        get
        {
            product.ID = long.Parse(textBoxID.Text);
            product.Brand = textBoxBrand.Text;
            product.Description = textBoxDescription.Text;
            product.Name = textBoxProductName.Text;
            product.NormalPrice = decimal.Parse(textBoxNormalPrice.Text);
            product.PurchasePrice = decimal.Parse(textBoxPurchasePrice.Text);
            product.SalePrice = decimal.Parse(textBoxSalesPrice.Text);
            product.Stock = long.Parse(textBoxStock.Text);
            product.Category = (Category)comboBoxCategory.SelectedItem;
            return product;
        }
    }
}