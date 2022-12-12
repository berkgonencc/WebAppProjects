using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Abstract
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll();
        void Delete(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task CreateAsync(TEntity entity);
    }
}
