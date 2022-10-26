using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.ICustomServices
{
    public interface IProductsService<T> where T : class
    {
        IEnumerable<T> GetAllProducts();
        T GetProductById(int Id);
        void AddProduct(T entity);
        void UpdateProduct(T entity);
        void DeleteProduct(T entity);
        IEnumerable<T> GetCategoryProducts(int categoryId);
    }
}
