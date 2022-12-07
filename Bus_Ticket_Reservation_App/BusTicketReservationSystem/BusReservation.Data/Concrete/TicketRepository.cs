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
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(MyAppContext _dbContext) : base(_dbContext)
        {

        }
        private MyAppContext context
        {
            get { return _dbContext as MyAppContext; }
        }
        public async Task<List<Ticket>> GetSelectedSeatsByResId(int resId)
        {
            return await context.Tickets.Where(t => t.TripId == resId).ToListAsync();
        }
       
    }
}
