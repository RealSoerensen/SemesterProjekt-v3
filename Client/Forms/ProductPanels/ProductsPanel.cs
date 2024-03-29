﻿using Client.Controllers;
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
    }

    private async void ProductsPanel_Load(object sender, EventArgs e)
    {
        try
        {
            products = await productController.GetAll();
            productGrid.DataSource = products;

            comboBox1.SelectedIndex = 12;
            comboBox1_SelectedIndexChanged(this, EventArgs.Empty);
        }
        catch (Exception ex)
        {
            MessageBox.Show(@"Kunne ikke hente produkter");
            Console.WriteLine(ex);
            Close();
        }
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

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var sortFilter = comboBox1.SelectedIndex;
        if (productGrid.DataSource is not List<Product> sortedProducts)
        {
            MessageBox.Show(@"Der er ingen produkter at sortere");
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
            12 => sortedProducts.OrderBy(product => product.ID).ToList(),
            13 => sortedProducts.OrderByDescending(product => product.ID).ToList(),
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

        CheckBox? senderCheckBox = sender as CheckBox;

        // Check which dictionary the senderCheckBox belongs to and uncheck others in that dictionary
        if (checkBoxesToCategories.ContainsKey(senderCheckBox))
        {
            if (senderCheckBox.Checked)
            {
                foreach (var checkBox in checkBoxesToCategories.Keys.Where(checkBox => checkBox != senderCheckBox))
                {
                    checkBox.Checked = false;
                }
            }
        }
        else if (checkBoxesToPriceRanges.ContainsKey(senderCheckBox))
        {
            if (senderCheckBox.Checked)
            {
                foreach (var checkBox in checkBoxesToPriceRanges.Keys.Where(checkBox => checkBox != senderCheckBox))
                {
                    checkBox.Checked = false;
                }
            }
        }

        var selectedCategories = checkBoxesToCategories
            .Where(kv => kv.Key.Checked)
            .Select(kv => kv.Value)
            .ToList();

        var selectedPriceRanges = checkBoxesToPriceRanges
            .Where(kv => kv.Key.Checked)
            .Select(kv => kv.Value)
            .ToList();


        List<Product> filteredProducts;

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

        if (selectedPriceRanges.Any())
        {
            filteredProducts = filteredProducts
                .Where(p => selectedPriceRanges.Any(range => p.SalePrice >= range.Item1 && p.SalePrice <= range.Item2))
                .ToList();
        }

        productGrid.DataSource = filteredProducts;
        comboBox1.SelectedIndex = 12;
    }

    private void productGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        var product = productGrid.Rows[e.RowIndex].DataBoundItem as Product;
        if (product == null) return;
        productGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = product.Inactive ? Color.DarkGray : productGrid.DefaultCellStyle.BackColor;

        product.NormalPrice = decimal.Round(product.NormalPrice, 2, MidpointRounding.AwayFromZero);
        product.SalePrice = decimal.Round(product.SalePrice, 2, MidpointRounding.AwayFromZero);
        product.PurchasePrice = decimal.Round(product.PurchasePrice, 2, MidpointRounding.AwayFromZero);
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

    private void productGrid_CellDoubleClick(object sender, EventArgs e)
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


    private bool FuzzyMatch(string produktName, string searchedText)
    {
        if (string.IsNullOrEmpty(searchedText))
        {
            return true;
        }

        var searchTextIndex = 0;

        foreach (var _ in produktName.Where(charFromText => searchedText[searchTextIndex] == charFromText))
        {
            searchTextIndex++;
            if (searchTextIndex == searchedText.Length)
            {
                return true;
            }
        }

        return false;
    }

    private void textBoxSearchbar_TextChanged(object sender, EventArgs e)
    {
        var searchValue = textBoxSearchbar.Text.ToLower();

        var filteredProducts = products.Where(p =>
            FuzzyMatch(p.Name.ToLower(), searchValue)).ToList();

        productGrid.DataSource = filteredProducts;
    }
}