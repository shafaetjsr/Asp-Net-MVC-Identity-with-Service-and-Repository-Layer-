using Companay.RepositoryContract;
using Company.DataLayer;
using Company.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companay.ServiceLayer
{
    public class ProductsService : IProductsService
    {
        private IProductsRepository prodRep;
        public ProductsService(IProductsRepository r)
        {
                this.prodRep = r;
        }
        
        public void DeleteProduct(int productId)
        {
           prodRep.DeleteProduct(productId);
        }

        public Product GetProductByID(int productId)
        {
            Product p = prodRep.GetProductByID(productId);
            return p;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = prodRep.GetProducts();
            return products;
        }

        public void InsertProduct(Product p)
        {
           prodRep.InsertProduct(p);
        }

        public List<Product> SearchProducts(string productName)
        {
            List<Product> p = prodRep.SearchProducts(productName);
            return p;
        }

        public void UpdateProduct(Product p)
        {
            prodRep.UpdateProduct(p);
        }
    }
}
