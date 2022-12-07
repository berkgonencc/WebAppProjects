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
    public class TripManager : ITripService
    {
        private ITripRepository _tripRepository;

        public TripManager(ITripRepository reservationRepository)
        {
            _tripRepository = reservationRepository;
        }

        public async Task CreateAsync(Trip entity)
        {
            await _tripRepository.CreateAsync(entity);
        }

  
        public void Delete(Trip entity)
        {
            _tripRepository.Delete(entity);
        }

        public async Task<List<Trip>> GetAllAsync()
        {
            return await _tripRepository.GetAllAsync();
        }

        public async Task<Trip> GetByIdAsync(int id)
        {
            return await _tripRepository.GetByIdAsync(id);
        }

        public async Task<List<Trip>> GetReservationListAsync(string departureCity, string arrivalCity, string tripDate)
        {
            return await _tripRepository.GetReservationListAsync(departureCity, arrivalCity, tripDate);
        }

        public void Update(Trip entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Trip trip)
        {
            await _tripRepository.UpdateAsync(trip);
        }
    }
}
