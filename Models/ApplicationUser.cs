using Microsoft.AspNetCore.Identity;

namespace LingvaApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string AvatarURL { get; set; }
        public string BannerURL { get; set; }
        public string AboutSelf { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string LearningLanguages { get; set; }
        public string NativeLanguages { get; set; }
    }
}
