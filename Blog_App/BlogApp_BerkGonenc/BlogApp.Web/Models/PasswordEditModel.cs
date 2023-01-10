using System.ComponentModel.DataAnnotations;

namespace BlogApp.Web.Models
{
    public class PasswordEditModel
    {
        public string UserId { get; set; }
        [Required(ErrorMessage = "Required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Required!")]
        [Compare("Password", ErrorMessage = "Passwords does not match!")]
        public string RePassword { get; set; }
    }
}
