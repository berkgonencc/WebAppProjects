using BusReservation.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservation.Business.Abstract
{
    public interface IPassengerService
    {
        Task CreateAsync(Passenger entity);
        Task<Passenger> GetByIdAsync(int id);
        Task<List<Passenger>> GetAllAsync();
        void Delete(Passenger entity);
        void Update(Passenger entity);
        Task CreateAsync(Passenger passenger, int seatNumber, int id);


    }
}
