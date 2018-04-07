using Myshop.Core.Models;
using MyShop.Core.Contracts;
using MyShop.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Myshop.UserUI.Controllers
{
    public class ProductSectionManagerController : Controller
    {

            IRepository<ProductSection> context;

            public ProductSectionManagerController(IRepository<ProductSection> context)
            {
                this.context = context;
            }
            // GET: ProductManager
            public ActionResult Index()
            {
                List<ProductSection> Productsections = context.Collection().ToList();
                return View(Productsections);
            }

            public ActionResult Create()
            {
                ProductSection Productsection = new ProductSection();
                return View(Productsection);
            }

            [HttpPost]
            public ActionResult Create(ProductSection Productsection)
            {
                if (!ModelState.IsValid)
                {
                    return View(Productsection);
                }
                else
                {
                    context.Insert(Productsection);
                    context.Commit();

                    return RedirectToAction("Index");
                }

            }

            public ActionResult Edit(string Id)
            {
                ProductSection Productsection = context.Find(Id);
                if (Productsection == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(Productsection);
                }
            }

            [HttpPost]
            public ActionResult Edit(ProductSection product, string Id)
            {
                ProductSection ProductsectionToEdit = context.Find(Id);

                if (ProductsectionToEdit == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    if (!ModelState.IsValid)
                    {
                        return View(product);
                    }

                    ProductsectionToEdit.Section = product.Section;

                    context.Commit();

                    return RedirectToAction("Index");
                }
            }

            public ActionResult Delete(string Id)
            {
                ProductSection ProductsectionToDelete = context.Find(Id);

                if (ProductsectionToDelete == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(ProductsectionToDelete);
                }
            }

            [HttpPost]
            [ActionName("Delete")]
            public ActionResult ConfirmDelete(string Id)
            {
                ProductSection ProductsectionToDelete = context.Find(Id);

                if (ProductsectionToDelete == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    context.Delete(Id);
                    return RedirectToAction("Index");
                }
            }
        }
    }