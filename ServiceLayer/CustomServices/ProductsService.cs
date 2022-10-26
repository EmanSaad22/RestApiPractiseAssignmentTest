using DomainLayer.Models;
using RepositoryLayer.IRepository;
using ServiceLayer.ICustomServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.CustomServices
{
    public class ProductsService : IProductsService<Products>
    {
        private readonly IRepository<Products> _productRepository;

        public ProductsService(IRepository<Products> productRepository)
        {
            _productRepository = productRepository;
        }
        public void DeleteProduct(Products product)
        {
            try
            {
                if (product != null)
                {
                    _productRepository.Delete(product);
                    _productRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Products GetProductById(int Id)
        {
            try
            {
                var product = _productRepository.Get(Id);
                if (product != null)
                {
                    return product;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Products> GetAllProducts()
        {
            try
            {
                var products = _productRepository.GetAll();
                if (products != null)
                {
                    return products;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Products> GetCategoryProducts(int categoryId)
        {
            var allProducts = _productRepository.GetAll();
            return allProducts.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void AddProduct(Products product)
        {
            try
            {
                if (product != null)
                {
                    _productRepository.Insert(product);
                    _productRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateProduct(Products product)
        {
            try
            {
                if (product != null)
                {
                    _productRepository.Update(product);
                    _productRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
