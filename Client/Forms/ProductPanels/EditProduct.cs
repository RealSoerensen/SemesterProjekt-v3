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

    public Product Product
    {
        get
        {
            return product;
        }
    }
}