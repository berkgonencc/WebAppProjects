using BusReservation.Business.Abstract;
using BusReservation.Data.Abstract;
using BusReservation.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservation.Business.Concrete
{
    public class CityManager : ICityService
    {
        private ICityRepository _cityRepository;

        public CityManager(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task CreateAsync(City entity)
        {
            await _cityRepository.CreateAsync(entity);
        }

        public async Task CreateCityAsync(City city)
        {
            await _cityRepository.CreateCityAsync(city);
        }

        public void Delete(City entity)
        {
            _cityRepository.Delete(entity);
        }

        public async Task<List<City>> GetAllAsync()
        {
            return await _cityRepository.GetAllAsync();
        }

        public async Task<City> GetByIdAsync(int id)
        {
            return await _cityRepository.GetByIdAsync(id);
        }

        public void Update(City entity)
        {
            _cityRepository.Update(entity);
        }
    }
}
