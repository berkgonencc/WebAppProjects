using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservation.Entity
{
    public class Trip
    {
        public int TripId { get; set; }
        public string DepartureTime { get; set; }
        public string ReservationDate { get; set; }
        public double? TicketPrice { get; set; }
        public string EstimatedTime { get; set; }
        public int BusId { get; set; }
        public int DepartureCityId { get; set; }
        [ForeignKey("DepartureCityId")]
        public City DepartureCity { get; set; }
        public int ArrivalCityId { get; set; }
        [ForeignKey("ArrivalCityId")]
        public City ArrivalCity { get; set; }


        public Bus Bus { get; set; }
        public List<Ticket> Tickets { get; set; }

    }
}
