using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entityes;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public int PageSize = 4;
        private IProductRepository repository;
        public HomeController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }
        public ViewResult Index(string category, int page=1, Cart cart=null)
        {
            // var r = repository.Products.OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize);
            //// var r = repository.Products.OrderBy(p => p.ProductID);
            // //return View(r.ToPagedList(page, PageSize));
            // return View(r);
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products.Where(o=>category==null||o.Category==category).OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems =category==null? repository.Products.Count():repository.Products.Count(o => o.Category==category)
                },
                CurrentCategory = category
            };
            if(cart != null && cart.Lines.Any())
            {
                ViewBag.Total = "(" + cart.Lines.AsEnumerable().Sum(o=>o.Quantity) + " ед.)";
            }
            return View(model);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //public PartialViewResult Summary(Cart cart)
        //{
        //    ViewBag.Total = cart;
        //    return PartialView();
        //}
    }
}