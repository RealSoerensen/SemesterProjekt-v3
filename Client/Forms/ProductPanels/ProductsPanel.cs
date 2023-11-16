using Client.Controllers;
using Models;

namespace Client.Forms.ProductPanels;

public partial class ProductsPanel : Form {
    private readonly ProductController productController = new();
    private List<Product> products = new();
    private Product? selectedProduct;

    public ProductsPanel() {
        InitializeComponent();
        InitializeDataGridView();
    }

    private void ProductsPanel_Load(object sender, EventArgs e) {
        try {
            products = productController.GetAll();
            productGrid.DataSource = products;
        } catch (Exception ex) {
            MessageBox.Show(@"Kunne ikke hente produkter");
            Console.WriteLine(ex);
            Close();
        }
    }

    private void InitializeDataGridView() {
        productGrid.Name = "Products";
        productGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        productGrid.DataSource = products;

        // Set the DataGridView to full row selection mode
        productGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        // Disable multi-select
        productGrid.MultiSelect = false;
    }


    private void productGrid_CellContentClick(object sender, DataGridViewCellEventArgs e) {
        // Select the whole row on click
        if (e.RowIndex < 0) return;
        var row = productGrid.Rows[e.RowIndex];
        row.Selected = true;
        selectedProduct = row.DataBoundItem as Product;
    }

    private void buttonEdit_Click(object sender, EventArgs e) {
        if (selectedProduct == null) return;

        var editProduct = new EditProduct(selectedProduct);
        editProduct.ShowDialog();

        // Check if the product was updated
        if (editProduct.DialogResult == DialogResult.OK) {
            RefreshProducts();
        }
    }

    private void RefreshProducts() {
        products = productController.GetAll();
        productGrid.DataSource = new List<Product>(products);
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

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
        var sortFilter = comboBox1.SelectedIndex;
        if (productGrid.DataSource is not List<Product> sortedProducts) {
            MessageBox.Show(@"Der er ingen kunder at sortere");
            return;
        }

        sortedProducts = sortFilter switch {
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
            _ => sortedProducts
        };
        productGrid.DataSource = sortedProducts;
    }

    private void CheckBox_CheckedChanged(object sender, EventArgs e) {
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
        if (!selectedCategories.Any()) {
            filteredProducts = new List<Product>(products);
        } else {
            filteredProducts = products
                .Where(p => selectedCategories.Contains(p.Category))
                .ToList();
        }

        // Apply price range filter if any price range is selected.
        if (selectedPriceRange != default) {
            filteredProducts = filteredProducts
                .Where(p => p.SalePrice >= selectedPriceRange.Item1 && p.SalePrice <= selectedPriceRange.Item2)
                .ToList();
        }

        productGrid.DataSource = filteredProducts;
    }

    private void btnCreateProduct_Click(object sender, EventArgs e) {
        var createProduct = new CreateProduct();
        createProduct.ShowDialog();

        // Check if the product was updated
        if (createProduct.DialogResult == DialogResult.OK) {
            RefreshProducts();
        }
    }

    private void buttonDelete_Click(object sender, EventArgs e) {
        if (selectedProduct == null) return;

        // Ask the user for confirmation before deletion
        var confirmationResult = MessageBox.Show(
            "Er du sikker på at du vil gøre " + selectedProduct.Name + " inaktiv?",
            "Fjern Bekræftelse",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        // Check the user's response
        if (confirmationResult == DialogResult.Yes) {
            var result = productController.Delete((long)selectedProduct.ID);

            if (result) {
                MessageBox.Show("Produkt fjernet.");
                RefreshProducts();
            } else {
                MessageBox.Show("Fejl: Produkt blev ikke fjernet.");
            }
        }
    }

}