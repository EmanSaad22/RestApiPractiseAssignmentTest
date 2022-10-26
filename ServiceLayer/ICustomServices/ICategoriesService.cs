using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.ICustomServices
{
    public interface ICategoriesService<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        T GetCategoryById(int Id);

    }
}
