using BusReservation.Entity;
using System.ComponentModel.DataAnnotations;

namespace BusReservation.Web.Models
{
    public class PaymentModel
    {
        [Required(ErrorMessage = "First Name is required!")]
        public string PassengerName { get; set; }
        [Required(ErrorMessage = "Last Name is required!")]
        public string PassengerSurname { get; set; }
        [Required(ErrorMessage = "Phone No. is required!")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage = "Email is required!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string Cvc { get; set; }
        public Trip Trip { get; set; }
    }
}
