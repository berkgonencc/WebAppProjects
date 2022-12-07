using BusReservation.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservation.Business.Abstract
{
    public interface ICityService
    {
        Task CreateAsync(City entity);
        Task<City> GetByIdAsync(int id);
        Task<List<City>> GetAllAsync();
        void Delete(City entity);
        void Update(City entity);
        Task CreateCityAsync(City city);

    }
}
