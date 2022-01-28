using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingvaApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string AvatarURL { get; set; }
    }
}
