using Company.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Companay.ServiceLayer;
using Company.ServiceContract;
using TestIdentity.Filters;

namespace TestIdentity.Controllers
{
    [MyAuthenticationFilters]
    [MyCustomerAuthonrization]
    public class ProductController : Controller
    {
        private IProductsService _productsService;

        public ProductController(IProductsService pService)
        {
            this._productsService = pService;
        }
        // GET: Product
        
        public ActionResult Index()
        {
            List<Product> p = _productsService.GetProducts();
            return View(p);
        }
    }
}