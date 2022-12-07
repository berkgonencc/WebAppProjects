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
    public class BusRepository : GenericRepository<Bus>, IBusRepository
    {
        public BusRepository(MyAppContext _dbContext) : base(_dbContext)
        {

        }
        private MyAppContext context
        {
            get { return _dbContext as MyAppContext; }
        }

    }
}
