using Microsoft.AspNetCore.Identity;

namespace Pri.identity.Api.Entities
{
	public class ApplicationUser : IdentityUser
	{
        public string City { get; set; }
    }
}
