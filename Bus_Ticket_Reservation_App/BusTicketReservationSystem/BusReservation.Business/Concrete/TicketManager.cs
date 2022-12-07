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
    public class TicketManager : ITicketService
    {
        private ITicketRepository _ticketRepository;

        public TicketManager(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task CreateAsync(Ticket entity)
        {
            await _ticketRepository.CreateAsync(entity);
        }
        
        public void Delete(Ticket entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Ticket>> GetAllAsync()
        {
            return await _ticketRepository.GetAllAsync();
        }

        public async Task<List<Ticket>> GetSelectedSeatsByResId(int resId)
        {
            return await _ticketRepository.GetSelectedSeatsByResId(resId);
        }

        public async Task<Ticket> GetByIdAsync(int id)
        {
            return await _ticketRepository.GetByIdAsync(id);
        }

        public void Update(Ticket entity)
        {
            throw new NotImplementedException();
        }

    }
}
