using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservation.Data.Abstract
{
    public interface IRepository<TEntity>
    {
        Task CreateAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(int id);
        Task<List<TEntity>> GetAllAsync();
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
