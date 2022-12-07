using System.ComponentModel.DataAnnotations;

namespace BusReservation.Web.Models
{
    public class PasswordEditModel
    {
        public string UserId { get; set; }
        [Required(ErrorMessage = "Bu alan zorunlu.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Bu alan zorunlu.")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor!")]
        public string RePassword { get; set; }
    }
}
