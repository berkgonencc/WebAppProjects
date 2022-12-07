using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservation.Entity
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }


        public List<Ticket> Tickets { get; set; }

    }
}
