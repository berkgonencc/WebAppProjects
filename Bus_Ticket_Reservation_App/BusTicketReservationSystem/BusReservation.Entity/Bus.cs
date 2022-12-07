                                                                                                                                                                                using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservation.Entity
{
    public class Bus
    {
        public int BusId { get; set; }
        public string BusName { get; set; }
        public int TotalSeats { get; set; }


        public List<Trip> Trips { get; set; }
    }
}
