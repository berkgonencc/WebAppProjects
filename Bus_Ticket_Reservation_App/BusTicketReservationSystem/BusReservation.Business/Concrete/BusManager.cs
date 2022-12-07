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
    public class BusManager : IBusService
    {
        private IBusRepository _busRepository;

        public BusManager(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        public async Task CreateAsync(Bus entity)
        {
            await _busRepository.CreateAsync(entity);
        }

        public void Delete(Bus entity)
        {
            _busRepository.Delete(entity);
        }

        public async Task<List<Bus>> GetAllAsync()
        {
            return await _busRepository.GetAllAsync();
        }

        public async Task<Bus> GetByIdAsync(int id)
        {
            return await _busRepository.GetByIdAsync(id);
        }
        public void Update(Bus entity)
        {
            _busRepository.Update(entity);
        }
    }
}
