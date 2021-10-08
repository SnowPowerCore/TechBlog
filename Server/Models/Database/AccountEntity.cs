using Microsoft.AspNetCore.Identity;

namespace PersonalTechBlog.Server.Models.Database
{
    public class AccountEntity : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}