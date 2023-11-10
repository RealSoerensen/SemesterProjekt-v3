using Models;

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
    }

    public Product Product
    {
        get
        {
            return product;
        }
    }
}