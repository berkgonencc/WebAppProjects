using BusReservation.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservation.Business.Abstract
{
    public interface ITicketService
    {
        Task CreateAsync(Ticket entity);
        Task<Ticket> GetByIdAsync(int id);
        Task<List<Ticket>> GetAllAsync();
        void Delete(Ticket entity);
        void Update(Ticket entity);
        Task<List<Ticket>> GetSelectedSeatsByResId(int resId);

    }
}
