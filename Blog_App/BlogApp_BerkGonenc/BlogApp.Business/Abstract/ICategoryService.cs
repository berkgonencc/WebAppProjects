using BlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Abstract
{
    public interface ICategoryService
    {
        Task<Category> GetById(int id);
        Task<List<Category>> GetAll();
        void Delete(Category entity);
        Task UpdateAsync(Category entity);
        Task CreateAsync(Category entity);
    }
}
