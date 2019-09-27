using Companay.ServiceLayer;
using Company.DataLayer;
using Company.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestIdentity.Filters;

namespace TestIdentity.Areas.Manager.Controllers
{
    [MyAuthenticationFilters]
    [MyManagerAuthorization]
    public class ProductController : Controller
    {
        private IProductsService ProductsService;

        public ProductController(IProductsService pService)
        {
            this.ProductsService = pService;
        }
        // GET: Manager/Product
        public ActionResult Index()
        {
            List<Product> p = ProductsService.GetProducts();
            return View(p);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product p = ProductsService.GetProductByID(id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            ProductsService.UpdateProduct(p);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Product p = ProductsService.GetProductByID(id);
            return View(p);
        }
    }
}