using Company.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companay.RepositoryContract
{
    public interface IProductsRepository
    {
        List<Product> GetProducts();
        List<Product> SearchProducts(string productName);
        Product GetProductByID(int productId);
        void InsertProduct(Product p);
        void UpdateProduct(Product p);
        void DeleteProduct(int productId);
    }
}
