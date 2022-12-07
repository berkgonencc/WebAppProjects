using BusReservation.Data.Abstract;
using BusReservation.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservation.Data.Concrete
{
    public class TripRepository : GenericRepository<Trip>, ITripRepository
    {
        public TripRepository(MyAppContext _dbContext) : base(_dbContext)
        {

        }
        private MyAppContext context
        {
            get { return _dbContext as MyAppContext; }
        }
        public async Task<List<Trip>> GetReservationListAsync(string departureCity, string arrivalCity, string tripDate)
        {
            return await context
                .Trips
                .Where(r => r.ReservationDate == tripDate && r.DepartureCityId.ToString() == departureCity && r.ArrivalCityId.ToString() == arrivalCity)
                .OrderBy(r => r.DepartureTime)
                .ToListAsync();
        }

        public async Task UpdateAsync(Trip trip)
        {
            Trip entity = await context.Trips.FirstOrDefaultAsync(r => r.TripId == trip.TripId);
            entity.DepartureTime = trip.DepartureTime;
            entity.ReservationDate = trip.ReservationDate;
            entity.TicketPrice = trip.TicketPrice;
            entity.EstimatedTime = trip.EstimatedTime;
            entity.ArrivalCityId = trip.ArrivalCityId;
            entity.DepartureCityId = trip.DepartureCityId;
            entity.BusId = trip.BusId;
            context.Update(entity);
            context.SaveChanges();
        }
    }
}
