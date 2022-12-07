using Microsoft.AspNetCore.Identity;

namespace BusReservation.Web.Identity
{
    public class User : IdentityUser
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
    }
}
