using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entityes;

namespace SportsStore.WebUI.Controllers
{
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
        //[HttpPost]
        //public ActionResult Edit(Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        productRepository.SaveProduct(product);
        //        TempData["message"] = string.Format("{0} : сохранено.", product.Name);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        // there is something wrong with the data values
        //        return View(product);
        //    }
        //}
        public ViewResult Create()
        {
            return View("Edit", new Product());
        }
        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deletedProduct = productRepository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedProduct.Name+"TEST");
             
            }
            return RedirectToAction("Index");
            //  return RedirectToAction("Edit", new Product());
        }
    }
}