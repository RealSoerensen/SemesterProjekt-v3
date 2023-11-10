using Client.Controllers;
using Models;

namespace Client.Forms.ProductPanels;

public partial class ProductsPanel : Form
{
    private readonly ProductController productController = new();
    private List<Product> products = new();
    private Product? selectedProduct;

    public ProductsPanel()
    {
        InitializeComponent();
        InitializeDataGridView();
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

    private void InitializeDataGridView()
    {
        productGrid.Name = "Products";
        productGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        productGrid.DataSource = products;
    }

    private void productGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        // Select the whole row on click
        if (e.RowIndex < 0) return;
        var row = productGrid.Rows[e.RowIndex];
        row.Selected = true;
        selectedProduct = row.DataBoundItem as Product;
    }

    private void btnCreateProduct_Click(object sender, EventArgs e)
    {
        return;
    }

    private void buttonEdit_Click(object sender, EventArgs e)
    {
        if (selectedProduct == null) return;
        var editProduct = new EditProduct(selectedProduct);
        editProduct.ShowDialog();
        if (editProduct.DialogResult != DialogResult.OK) return;
        productController.Update(editProduct.Product);
        var index = products.FindIndex(p => p.ID == selectedProduct.ID);
        products[index] = selectedProduct;
        productGrid.DataSource = products;
    }
}