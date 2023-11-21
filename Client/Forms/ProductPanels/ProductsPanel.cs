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

    private async void ProductsPanel_Load(object sender, EventArgs e)
    {
        try
        {
            products = await productController.GetAll();
            productGrid.DataSource = products;
        }
        catch (Exception ex)
        {
            MessageBox.Show(@"Kunne ikke hente produkter");
            Console.WriteLine(ex);
            Close();
        }
    }

    private void InitializeDataGridView()
    {
        productGrid.Name = "Products";
        productGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        productGrid.DataSource = products;

        // Set the DataGridView to full row selection mode
        productGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        // Disable multi-select
        productGrid.MultiSelect = false;
    }

    private void productGrid_SelectionChanged(object sender, EventArgs e)
    {
        if (productGrid.SelectedRows.Count <= 0) return;
        var selectedRow = productGrid.SelectedRows[0];
        selectedProduct = selectedRow.DataBoundItem as Product;
    }


    private void buttonEdit_Click(object sender, EventArgs e)
    {
        if (selectedProduct == null) return;

        var editProduct = new EditProduct(selectedProduct);
        editProduct.ShowDialog();

        // Check if the product was updated
        if (editProduct.DialogResult == DialogResult.OK)
        {
            RefreshProducts();
        }
    }

    private async void RefreshProducts()
    {
        var firstDisplayedScrollingRowIndex = productGrid.FirstDisplayedScrollingRowIndex;
        var selectedRowIndex = -1;
        if (productGrid.SelectedRows.Count > 0)
        {
            selectedRowIndex = productGrid.SelectedRows[0].Index;
        }

        productGrid.DataSource = null;
        products = await productController.GetAll();
        productGrid.DataSource = products;

        try
        {
            if (firstDisplayedScrollingRowIndex >= 0)
            {
                productGrid.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
            }
            if (selectedRowIndex >= 0 && selectedRowIndex < productGrid.Rows.Count)
            {
                productGrid.Rows[selectedRowIndex].Selected = true;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error while trying to restore grid position and selection: " + ex.Message);
        }
    }


    // Combobox items
    /*
     * Name (a-å)
     * Name (å-a)
     * SalePrice (høj-lav)
     * SalePrice (lav-høj)
     * PurchasePrice (høj-lav)
     * PurchasePrice (lav-høj)
     * NormalPrice (høj-lav)
     * NormalPrice (lav-høj)
     * Stock (høj-lav)
     * Stock (lav-høj)
    */

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var sortFilter = comboBox1.SelectedIndex;
        if (productGrid.DataSource is not List<Product> sortedProducts)
        {
            MessageBox.Show(@"Der er ingen kunder at sortere");
            return;
        }

        sortedProducts = sortFilter switch
        {
            0 => sortedProducts.OrderBy(product => product.Name).ToList(),
            1 => sortedProducts.OrderByDescending(product => product.Name).ToList(),
            2 => sortedProducts.OrderByDescending(product => product.SalePrice).ToList(),
            3 => sortedProducts.OrderBy(product => product.SalePrice).ToList(),
            4 => sortedProducts.OrderByDescending(product => product.PurchasePrice).ToList(),
            5 => sortedProducts.OrderBy(product => product.PurchasePrice).ToList(),
            6 => sortedProducts.OrderByDescending(product => product.NormalPrice).ToList(),
            7 => sortedProducts.OrderBy(product => product.NormalPrice).ToList(),
            8 => sortedProducts.OrderByDescending(product => product.Stock).ToList(),
            9 => sortedProducts.OrderBy(product => product.Stock).ToList(),
            10 => sortedProducts.OrderByDescending(product => product.Inactive).ToList(),
            11 => sortedProducts.OrderBy(product => product.Inactive).ToList(),
            _ => sortedProducts
        };
        productGrid.DataSource = sortedProducts;
    }

    private void CheckBox_CheckedChanged(object sender, EventArgs e)
    {
        var checkBoxesToCategories = new Dictionary<CheckBox, Category>
        {
        { checkBoxRacket, Category.Bats },
        { checkBoxBalls, Category.Balls },
        { checkBoxShoes, Category.Shoes },
        { checkBoxClothes, Category.Clothes },
        { checkBoxBags, Category.Bags },
        { checkBoxAccessories, Category.Accessories }
    };

        var checkBoxesToPriceRanges = new Dictionary<CheckBox, (decimal, decimal)>
        {
        { checkBoxPrice1, (0, 150) },
        { checkBoxPrice2, (150, 300) },
        { checkBoxPrice3, (300, 500) },
        { checkBoxPrice4, (500, 1000) },
        { checkBoxPrice5, (1000, 1500) },
        { checkBoxPrice6, (1500, decimal.MaxValue) }
    };

        var selectedCategories = checkBoxesToCategories
            .Where(kv => kv.Key.Checked)
            .Select(kv => kv.Value)
            .ToList();

        var selectedPriceRange = checkBoxesToPriceRanges
            .Where(kv => kv.Key.Checked)
            .Select(kv => kv.Value)
            .FirstOrDefault(); // Take the first selected price range

        List<Product> filteredProducts;

        // If no category is selected, display all products; otherwise, filter by selected categories.
        if (!selectedCategories.Any())
        {
            filteredProducts = new List<Product>(products);
        }
        else
        {
            filteredProducts = products
                .Where(p => selectedCategories.Contains(p.Category))
                .ToList();
        }

        // Apply price range filter if any price range is selected.
        if (selectedPriceRange != default)
        {
            filteredProducts = filteredProducts
                .Where(p => p.SalePrice >= selectedPriceRange.Item1 && p.SalePrice <= selectedPriceRange.Item2)
                .ToList();
        }

        productGrid.DataSource = filteredProducts;
    }

    private void productGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        var product = productGrid.Rows[e.RowIndex].DataBoundItem as Product;
        if (product != null)
        {
            if (product.Inactive)
            {
                productGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;
            }
            else
            {
                productGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = productGrid.DefaultCellStyle.BackColor;
            }

            product.NormalPrice = decimal.Round(product.NormalPrice, 2, MidpointRounding.AwayFromZero);
            product.SalePrice = decimal.Round(product.SalePrice, 2, MidpointRounding.AwayFromZero);
            product.PurchasePrice = decimal.Round(product.PurchasePrice, 2, MidpointRounding.AwayFromZero);
        }
    }



    private void btnCreateProduct_Click(object sender, EventArgs e)
    {
        var createProduct = new CreateProduct();
        createProduct.ShowDialog();

        // Check if the product was updated
        if (createProduct.DialogResult == DialogResult.OK)
        {
            RefreshProducts();
        }
    }

    private void productGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            if (selectedProduct == null) return;

            var editProduct = new EditProduct(selectedProduct);
            editProduct.ShowDialog();

            // Check if the product was updated
            if (editProduct.DialogResult == DialogResult.OK)
            {
                RefreshProducts();
            }
        }
    }

    private void FilterProducts()
    {
        var searchValue = textBoxSearchbar.Text.ToLower();

        var filteredProducts = products.Where(p =>
            FuzzyMatch(p.Name.ToLower(), searchValue)).ToList();

        productGrid.DataSource = filteredProducts;
    }



    private bool FuzzyMatch(string text, string searchTerm)
    {
        if (string.IsNullOrEmpty(searchTerm))
        {
            return true;
        }

        var searchTextIndex = 0;

        foreach (var charFromText in text.Where(charFromText => searchTerm[searchTextIndex] == charFromText))
        {
            searchTextIndex++;
            if (searchTextIndex == searchTerm.Length)
            {
                return true;
            }
        }

        return false;
    }



    private void textBoxSearchbar_TextChanged(object sender, EventArgs e)
    {
        FilterProducts();
    }
}