using System.ComponentModel.DataAnnotations;

namespace BusReservation.Web.Models
{
    public class BusModel
    {
        public int BusId { get; set; }
        [Required]
        [Display(Name ="Model")]
        public string BusName { get; set; }
        [Required]
        public int Capacity { get; set; }
    }
}
