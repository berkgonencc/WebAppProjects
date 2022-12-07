using System.ComponentModel.DataAnnotations;

namespace BusReservation.Web.Models
{
    public class CityModel
    {
        public int CityId { get; set; }
        [Required]
        [Display(Name ="City")]
        public string CityName { get; set; }
    }
}
