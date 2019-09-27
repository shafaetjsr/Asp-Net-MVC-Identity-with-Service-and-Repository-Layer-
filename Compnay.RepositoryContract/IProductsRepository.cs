using Company.DataLayer;
using System;
using System.Collections.Generic;

namespace Compnay.RepositoryContract
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
