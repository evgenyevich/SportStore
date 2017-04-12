using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entityes;

namespace SportsStore.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository productRepository;

        public AdminController(IProductRepository repo)
        {
            productRepository = repo;
        }
        public ViewResult Index()
        {
            return View(productRepository.Products);
        }
        public ViewResult Edit(int productId)
        {
            Product product = productRepository.Products
            .FirstOrDefault(p => p.ProductID == productId);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.SaveProduct(product);
                TempData["message"] = string.Format("{0} : сохранено.", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
        public ViewResult Create()
        {
            return View("Edit", new Product());
        }
        //[HttpPost]
        public ActionResult DropProduct(int productId)
        {
            Product deletedProduct = productRepository.DeleteProduct(productId);
          //  Product deletedProduct = productRepository.Products.First(o => o.ProductID == productId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} удален";
            }
            return RedirectToAction("Index");
        }
    }
}