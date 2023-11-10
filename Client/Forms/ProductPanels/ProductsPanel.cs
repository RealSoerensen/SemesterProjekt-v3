using Client.Controllers;
using Models;

namespace Client.Forms.ProductPanels;

public partial class ProductsPanel : Form
{
    private readonly ProductController productController = new();
    private List<Product> products = new();

    public ProductsPanel()
    {
        InitializeComponent();
    }

    private void ProductsPanel_Load(object sender, EventArgs e)
    {
        try
        {
            products = productController.GetAll();
        }
        catch (Exception ex)
        {
            MessageBox.Show(@"Kunne ikke hente produkter");
            Console.WriteLine(ex);
            Close();
        }

        productGrid.DataSource = products;
    }

    private void productGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        var product = products[e.RowIndex];
        var editProduct = new EditProduct(product);
        editProduct.ShowDialog();
        if (editProduct.DialogResult != DialogResult.OK) return;
        productController.Update(editProduct.Product);
        var index = products.FindIndex(p => p.ID == product.ID);
        products[index] = product;
        productGrid.DataSource = products;
    }

    private void btnCreateProduct_Click(object sender, EventArgs e)
    {
        return;
    }
}