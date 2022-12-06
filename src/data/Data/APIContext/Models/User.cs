using Microsoft.AspNetCore.Identity;

namespace data.Data.APIContext.Models
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}