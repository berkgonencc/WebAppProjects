using BusReservation.Entity;

namespace BusReservation.Web.Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int SeatNo { get; set; }
        public Trip? Trip { get; set; } = null!;

    }
}
