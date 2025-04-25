using Microsoft.AspNetCore.Identity;

namespace FirstWebAppRwad.IdentityModels
{
    public class ApplicationUser:IdentityUser
    {
        public string Address { get; set; }
    }
}
