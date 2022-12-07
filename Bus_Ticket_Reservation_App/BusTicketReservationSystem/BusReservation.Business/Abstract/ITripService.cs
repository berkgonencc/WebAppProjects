using BusReservation.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservation.Business.Abstract
{
    public interface ITripService
    {
        Task CreateAsync(Trip entity);
        Task<Trip> GetByIdAsync(int id);
        Task<List<Trip>> GetAllAsync();
        void Delete(Trip entity);
        void Update(Trip entity);
        Task<List<Trip>> GetReservationListAsync(string departureCity, string arrivalCity,string tripDate);
        Task UpdateAsync(Trip trip);


    }
}
