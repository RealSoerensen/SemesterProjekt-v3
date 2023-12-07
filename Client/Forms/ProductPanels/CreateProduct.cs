using Client.Controllers;
using Models;

namespace Client.Forms.ProductPanels;

public partial class CreateProduct : Form
{
    private readonly ProductController productController = new();
    public CreateProduct()
    {
        InitializeComponent();

        comboBoxCategory.DataSource = Enum.GetValues(typeof(Category));
        comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }

    private Product Product
    {
        get
        {
            var imageBase64 = ProductController.ConvertImageToBase64(pictureBoxImage.Image);
            var salesPrice = decimal.Parse(textBoxSalesPrice.Text);
            var purchasePrice = decimal.Parse(textBoxPurchasePrice.Text);
            var normalPrice = decimal.Parse(textBoxNormalPrice.Text);
            var stock = int.Parse(textBoxStock.Text);
            var category = (Category)Enum.Parse(typeof(Category), comboBoxCategory.Text);

            return new Product(
                textBoxDescription.Text,
                imageBase64,
                salesPrice,
                purchasePrice,
                normalPrice,
                textBoxProductName.Text,
                stock,
                textBoxBrand.Text,
                category
            );
        }
    }

    private void buttonChoosePicture_Click(object sender, EventArgs e)
    {
        using var openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
        openFileDialog.Title = "Select a Product Image";

        if (openFileDialog.ShowDialog() != DialogResult.OK) return;
        var originalImage = Image.FromFile(openFileDialog.FileName);
        pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;

        // Now you can use the resized image
        pictureBoxImage.Image = originalImage;
    }

    private async void buttonCreate_Click(object sender, EventArgs e)
    {
        if (!ValidateProductInput())
        {
            return;
        }

        var product = await productController.Create(Product);

        if (product == null)
        {
            MessageBox.Show(@"Produktet blev ikke oprettet.");
            return;
        }

        MessageBox.Show(@"Produktet blev oprettet.");
        Close();
    }

    private bool ValidateProductInput()
    {
        if (string.IsNullOrWhiteSpace(textBoxProductName.Text))
        {
            MessageBox.Show(@"Produktnavn er påkrævet.");
            return false;
        }
        if (string.IsNullOrWhiteSpace(textBoxBrand.Text))
        {
            MessageBox.Show(@"Mærke er påkrævet.");
            return false;
        }
        if (string.IsNullOrWhiteSpace(textBoxDescription.Text))
        {
            MessageBox.Show(@"Beskrivelse er påkrævet.");
            return false;
        }
        if (!decimal.TryParse(textBoxSalesPrice.Text, out var salePrice) || salePrice <= 0)
        {
            MessageBox.Show(@"Ugyldig salgspris. Det skal være et positivt tal.");
            return false;
        }
        if (!decimal.TryParse(textBoxPurchasePrice.Text, out var purchasePrice) || purchasePrice <= 0)
        {
            MessageBox.Show(@"Ugyldig købspris. Det skal være et positivt tal.");
            return false;
        }
        if (!decimal.TryParse(textBoxNormalPrice.Text, out var normalPrice) || normalPrice <= 0)
        {
            MessageBox.Show(@"Ugyldig normalpris. Det skal være et positivt tal.");
            return false;
        }
        if (!long.TryParse(textBoxStock.Text, out var stock) || stock < 0)
        {
            MessageBox.Show(@"Ugyldig lagerantal. Det kan ikke være negativt.");
            return false;
        }

        return true;
    }
}