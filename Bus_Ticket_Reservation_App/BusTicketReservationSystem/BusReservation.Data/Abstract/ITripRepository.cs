using BusReservation.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservation.Data.Abstract
{
    public interface ITripRepository : IRepository<Trip>
    {
        Task<List<Trip>> GetReservationListAsync(string departureCity, string arrivalCity,string tripDate);
        Task UpdateAsync(Trip trip);
    }
}
