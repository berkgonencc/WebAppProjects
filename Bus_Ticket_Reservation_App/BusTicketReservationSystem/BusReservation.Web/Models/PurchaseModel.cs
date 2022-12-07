using BusReservation.Entity;
using System.ComponentModel.DataAnnotations;

namespace BusReservation.Web.Models
{
    public class PurchaseModel
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required!")]
        public string Fname { get; set; }
        [Required(ErrorMessage = "Last name is required!")]
        [Display(Name = "Last Name")]
        public string Lname { get; set; }
        [Required(ErrorMessage = "Email is required!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]    
        [Display(Name = "Phone No.")]
        [Required(ErrorMessage = "Phone number is required!")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Card Holder Name is required!")]
        [Display(Name = "Card Holder Name")]
        public string CardHolderName { get; set; }
        [Display(Name ="Credit Card Number")]
        [Required(ErrorMessage = "Credit Card Number is required!")]
        [MaxLength(16)]
        [MinLength(16)]
        public string CardNumber { get; set; }
        [Display(Name = "Month")]
        [Required(ErrorMessage = "Expiration Month is required!")]
        [MaxLength(2)]
        [MinLength(2)]
        public string ExpirationMonth { get; set; }
        [Display(Name = "Year")]
        [Required(ErrorMessage = "Expiration Year is required!")]
        [MaxLength(4)]
        [MinLength(4)]
        public string ExpirationYear { get; set; }
        [Required(ErrorMessage = "Cvc is required!")]
        [MaxLength(3)]
        [MinLength(3)]
        public string Cvc { get; set; }
        public Trip? Trip { get; set; } = null!;
        public List<Ticket>? SelectedSeats { get; set; } = null!;

    }
}
