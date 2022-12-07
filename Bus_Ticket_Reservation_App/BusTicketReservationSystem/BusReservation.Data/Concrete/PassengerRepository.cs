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
    public class PassengerRepository : GenericRepository<Passenger>, IPassengerRepository
    {
        public PassengerRepository(MyAppContext _dbContext) : base(_dbContext)
        {

        }
        private MyAppContext context
        {
            get { return _dbContext as MyAppContext; }
        }

        public async Task CreateAsync(Passenger passenger, int seatNumber, int id)
        {   
            await context.AddAsync(passenger);
            await context.SaveChangesAsync();
            var ticket = context.Tickets.Select(t => new Ticket()
            {
                PassengerId = passenger.PassengerId,
                SeatNo = seatNumber,
                TripId = id
            }).FirstOrDefault();
            await context.Tickets.AddAsync(ticket);
            await context.SaveChangesAsync();
        }
    }
}
