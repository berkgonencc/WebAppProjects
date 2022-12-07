using BusReservation.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservation.Business.Abstract
{
    public interface IBusService
    {
        Task CreateAsync(Bus entity);
        Task<Bus> GetByIdAsync(int id);
        Task<List<Bus>> GetAllAsync();
        void Delete(Bus entity);
        void Update(Bus entity);

    }
}
