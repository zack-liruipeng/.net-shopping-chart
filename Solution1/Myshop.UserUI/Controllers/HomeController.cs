using Myshop.Core.Models;
using Myshop.Core.ViewModels;
using MyShop.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Myshop.UserUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Product> context;
        IRepository<ProductSection> productsections;

        public HomeController(IRepository<Product> productcontext, IRepository<ProductSection> productsectioncontext)
        {
            context = productcontext;
            productsections = productsectioncontext;
        }

        public ActionResult Index(string Section = null)
        {
            List<Product> products = context.Collection().ToList();
            List<ProductSection> sections = productsections.Collection().ToList();

            if (Section ==  null)
            {
                context.Collection().ToList();
            }
            else
            {
                products = context.Collection().Where(p => p.Section == Section).ToList();

            }

            ProductListViewModel model = new ProductListViewModel();
            model.Products = products;
            model.ProductSections = sections;

            return View(model);
        }

        public ActionResult Details(string Id)
        {
            Product product = context.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
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
    }
}