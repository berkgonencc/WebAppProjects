using BusReservation.Data.Abstract;
using BusReservation.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservation.Data.Concrete
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(MyAppContext _dbContext) : base(_dbContext)
        {

        }
        private MyAppContext context
        {
            get { return _dbContext as MyAppContext; }
        }

        public async Task CreateCityAsync(City city)
        {
            var registeredCity = context.Cities.Where(c=>c.CityName== city.CityName).Select(c=>c.CityName).FirstOrDefault();
            if (city.CityName != registeredCity)
            {
                await context.AddAsync(city);
                await context.SaveChangesAsync();
            }
          
        }
    }
}
