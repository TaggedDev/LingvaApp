using Microsoft.AspNetCore.Identity;

namespace LingvaApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string AvatarURL { get; set; }
    }
}
