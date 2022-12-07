using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservation.Entity
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int PassengerId { get; set; }
        public int TripId { get; set; }
        public int? SeatNo { get; set; }


        public Trip Trip { get; set; }
        public Passenger Passenger { get; set; }

    }
}
