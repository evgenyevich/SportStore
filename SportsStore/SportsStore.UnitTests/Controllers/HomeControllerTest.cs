using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entityes;
using SportsStore.WebUI;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTests.Controllers
{
    [TestClass]
    public partial class HomeControllerTest
    {
        [TestMethod]
        public void Can_Paginate()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                                    new Product {ProductID = 1, Name = "P1"},
                                    new Product {ProductID = 2, Name = "P2"},
                                    new Product {ProductID = 3, Name = "P3"},
                                    new Product {ProductID = 4, Name = "P4"},
                                    new Product {ProductID = 5, Name = "P5"}
                                    }.AsQueryable());
            HomeController controller = new HomeController(mock.Object);
            controller.PageSize = 3;
            // Act
            var result = (ProductsListViewModel)controller.Index(null,1).Model;
            // Assert
            Product[] prodArray = result.Products.OrderBy(o=>o.ProductID).ToArray();
            Assert.IsTrue(prodArray.Length ==3);
            Assert.AreEqual(prodArray[0].Name, "P1");
            Assert.AreEqual(prodArray[prodArray.Count()-1].Name, "P3");
        }
        [TestMethod]
        public void Can_Filter_Products()
        {
            // Arrange
            // - create the mock repository
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
new Product {ProductID = 1, Name = "P1", Category = "Cat1"},
new Product {ProductID = 2, Name = "P2", Category = "Cat2"},
new Product {ProductID = 3, Name = "P3", Category = "Cat1"},
new Product {ProductID = 4, Name = "P4", Category = "Cat2"},
new Product {ProductID = 5, Name = "P5", Category = "Cat3"}
}.AsQueryable());
            // Arrange - create a controller and make the page size 3 items
            HomeController controller = new HomeController(mock.Object);
            controller.PageSize = 3;
            // Action
            Product[] result = ((ProductsListViewModel)controller.Index("Cat2", 1).Model)
            .Products.ToArray();
            // Assert
            Assert.AreEqual(result.Length, 2);
            Assert.IsTrue(result[0].Name == "P2" && result[0].Category == "Cat2");
            Assert.IsTrue(result[1].Name == "P4" && result[1].Category == "Cat2");
        }
        [TestClass]
        public class CartTests
        {
            [TestMethod]
            public void Can_Add_New_Lines()
            {
                // Arrange - create some test products
                Product p1 = new Product { ProductID = 1, Name = "P1" };
                Product p2 = new Product { ProductID = 2, Name = "P2" };
                // Arrange - create a new cart
                Cart target = new Cart();
                // Act
                target.AddItem(p1, 1);
                target.AddItem(p2, 1);
                CartLine[] results = target.Lines.ToArray();
                // Assert
                Assert.AreEqual(results.Length, 2);
                Assert.AreEqual(results[0].Product, p1);
                Assert.AreEqual(results[1].Product, p2);
            }
        }
    }

}

