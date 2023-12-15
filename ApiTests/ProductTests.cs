using Models;
using RESTful_API.Services;

namespace ApiTests;

[TestClass]
public class ProductTests
{
    private readonly ProductService productService;

    public ProductTests()
    {
        productService = new();
    }

    [TestMethod]
    public void ShouldCreateProduct()
    {
        //Arrange
        var product = new Product("TestDesc", "TestImage", 10, 10, 10, "TestName", 10, "TestBrand", Category.Shoes);

        //Act
        var createdProduct = productService.CreateProduct(product);

        //Assert
        Assert.IsNotNull(createdProduct);
    }

    [TestMethod]
    public async Task ShouldUpdateProduct()
    {
        //Arrange
        var product = new Product("TestDesc", "TestImage", 10, 10, 10, "TestName", 10, "TestBrand", Category.Shoes);
        var createdProduct = await productService.CreateProduct(product);
        createdProduct.Name = "UpdatedTestName";

        //Act
        var isUpdated = await productService.UpdateProduct(createdProduct);

        //Assert
        Assert.IsTrue(isUpdated);
    }

    [TestMethod]
    public async Task ShouldGetProduct()
    {
        //Arrange
        var product = new Product("TestDesc", "TestImage", 10, 10, 10, "TestName", 10, "TestBrand", Category.Shoes);
        var createdProduct = await productService.CreateProduct(product);

        //Act
        var gettedProduct = await productService.GetProductByID((long)createdProduct.ID);

        //Assert
        Assert.AreEqual(createdProduct.ID, gettedProduct.ID);
    }

    [TestMethod]
    public async Task ShouldGetAllProducts()
    {
        //Arrange
        var product = new Product("TestDesc", "TestImage", 10, 10, 10, "TestName", 10, "TestBrand", Category.Shoes);
        var createdProduct = await productService.CreateProduct(product);

        //Act
        var gettedProducts = await productService.GetAllProducts();

        //Assert
        Assert.IsTrue(gettedProducts.Count > 0);
    }
}
