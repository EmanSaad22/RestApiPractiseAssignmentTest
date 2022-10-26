using DomainLayer.Models;
using RepositoryLayer.IRepository;
using ServiceLayer.ICustomServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.CustomServices
{
    public class CategoriesService : ICategoriesService<Category>
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoriesService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetAll()
        {
            try
            {
                var categories = _categoryRepository.GetAll();
                if (categories != null)
                    return categories;
                else
                    return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Add(Category entity)
        {
            try
            {
                if (entity != null)
                {
                    _categoryRepository.Insert(entity);
                    _categoryRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Category GetCategoryById(int Id)
        {
            try
            {
                var category = _categoryRepository.Get(Id);
                if (category != null)
                {
                    return category;
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

    }
}
