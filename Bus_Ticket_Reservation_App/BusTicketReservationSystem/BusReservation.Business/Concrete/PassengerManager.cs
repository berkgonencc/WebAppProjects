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
    public class PassengerManager : IPassengerService
    {
        private IPassengerRepository _passengerRepository;

        public PassengerManager(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        public async Task CreateAsync(Passenger entity)
        {
            await _passengerRepository.CreateAsync(entity);
        }

        public async Task CreateAsync(Passenger passenger, int seatNumber, int id)
        {
            await _passengerRepository.CreateAsync(passenger, seatNumber, id);
        }

        public void Delete(Passenger entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Passenger>> GetAllAsync()
        {
            return await _passengerRepository.GetAllAsync();
        }

        public async Task<Passenger> GetByIdAsync(int id)
        {
            return await _passengerRepository.GetByIdAsync(id);
        }

        public void Update(Passenger entity)
        {
            throw new NotImplementedException();
        }
    }
}
