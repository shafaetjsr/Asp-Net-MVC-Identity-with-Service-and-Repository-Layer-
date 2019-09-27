using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Companay.RepositoryContract;
using Company.DataLayer;

namespace Compnay.RepositoryLayer
{
    public class ProductsRepository : IProductsRepository
    {
        private EFDBFirstDatabaseEntities db;

        public ProductsRepository()
        {
            this.db = new EFDBFirstDatabaseEntities();
        }
        public void DeleteProduct(int productId)
        {
            Product p = db.Products.Where(x => x.ProductID == productId).FirstOrDefault();
            db.Products.Remove(p);
            db.SaveChanges();
        }

        public Product GetProductByID(int productId)
        {
            Product p = db.Products.Where(x => x.ProductID == productId).FirstOrDefault();
            return p;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = db.Products.ToList();
            return products;
        }

        public void InsertProduct(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
        }

        public List<Product> SearchProducts(string productName)
        {
            List<Product> p = db.Products.Where(x => x.ProductName == productName).ToList();
            return p;
        }

        public void UpdateProduct(Product p)
        {
            Product exp = db.Products.Where(x => x.ProductID == p.ProductID).FirstOrDefault();
            exp.ProductName = p.ProductName;
            exp.Price = p.Price;
            exp.DateOfPurchase = p.DateOfPurchase;
            exp.CategoryID = p.CategoryID;
            exp.BrandID = p.BrandID;
            exp.AvailabilityStatus = p.AvailabilityStatus;
            exp.Active = p.Active;
            db.SaveChanges();
        }
    }
}
