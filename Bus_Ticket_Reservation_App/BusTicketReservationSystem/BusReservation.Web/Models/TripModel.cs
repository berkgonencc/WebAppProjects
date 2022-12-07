using BusReservation.Entity;
using System.ComponentModel.DataAnnotations;

namespace BusReservation.Web.Models
{
    public class TripModel
    {
        public int TripId { get; set; }
        [Display(Name = "Departure Time")]
        [Required(ErrorMessage= "Departure Time is required!")]
        public string DepartureTime { get; set; }
        [Display(Name = "Reservation Date")]
        [Required(ErrorMessage = "Reservation Date is required!")]
        public string ReservationDate { get; set; }
        [Display(Name = "Ticket Price (₺)")]
        [Required(ErrorMessage = "Price is required!")]
        [Range(0,2000,ErrorMessage ="0-2000")]
        public double? TicketPrice { get; set; }
        [Required(ErrorMessage = "Estimated Time is required!")]
        [Display(Name = "Estimated Time (hrs)")]
        public string EstimatedTime { get; set; }
        public int? DepartureCityId { get; set; }    
        public int? ArrivalCityId { get; set; }  
        public int? BusId { get; set; }

    }
}
