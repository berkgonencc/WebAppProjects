using Microsoft.AspNetCore.Identity;

namespace BlogApp.Web.Identity
{
    public class User : IdentityUser
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
    }
}
