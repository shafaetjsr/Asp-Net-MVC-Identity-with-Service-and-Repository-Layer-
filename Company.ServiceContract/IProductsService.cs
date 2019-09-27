using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.DataLayer;

namespace Company.ServiceContract
{
    public interface IProductsService
    {
        List<Product> GetProducts();
        List<Product> SearchProducts(string productName);
        Product GetProductByID(int productId);
        void InsertProduct(Product p);
        void UpdateProduct(Product p);
        void DeleteProduct(int productId);
    }
}
