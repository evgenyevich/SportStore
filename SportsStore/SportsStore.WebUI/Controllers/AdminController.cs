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
    }
}