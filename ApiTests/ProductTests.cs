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
        var newProduct = new Product("TestDesc", "TestImage", 10, 10, 10, "TestName", 10, "TestBrand", 0);

        //Act
        var createdProduct = productService.CreateProduct(newProduct);

        //Assert
        Assert.IsNotNull(createdProduct);
    }

    [TestMethod]
    public void ShouldUpdateProduct()
    {
        //Arrange
        var newProduct = new Product("TestDesc", "TestImage", 10, 10, 10, "TestName", 10, "TestBrand", 0);
        var createdProduct = productService.CreateProduct(newProduct).Result;

        //Act
        createdProduct.Description = "UpdatedTestDesc";
        var isProductUpdated = productService.UpdateProduct(createdProduct).Result;

        //Assert
        Assert.IsTrue(isProductUpdated);
        Assert.AreEqual(createdProduct.Description, "UpdatedTestDesc");
    }

    [TestMethod]
    public void ShouldGetProduct()
    {
        //Arrange
        var newProduct = new Product("TestDesc", "TestImage", 10, 10, 10, "TestName", 10, "TestBrand", 0);
        var createdProduct = productService.CreateProduct(newProduct).Result;

        //Act


        //Assert
        throw new NotImplementedException();
    }

    [TestMethod]
    public void ShouldGetAllProducts()
    {
        //Arrange
        var newProduct = new Product("TestDesc", "TestImage", 10, 10, 10, "TestName", 10, "TestBrand", 0);
        var createdProduct = productService.CreateProduct(newProduct).Result;

        //Act


        //Assert
        throw new NotImplementedException();
    }

    [TestMethod]
    public void ShouldDeleteProduct()
    {
        //Arrange
        var newProduct = new Product("TestDesc", "TestImage", 10, 10, 10, "TestName", 10, "TestBrand", 0);
        var createdProduct = productService.CreateProduct(newProduct).Result;

        //Act


        //Assert
        throw new NotImplementedException();
    }
}
