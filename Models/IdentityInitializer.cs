using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LingvaApp.Models
{
    public class IdentityInitializer
    {
        public static async void InitializeAsync(IServiceProvider provider)
        {
            RoleManager<IdentityRole> roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            UserManager<ApplicationUser> userManager = provider.GetRequiredService<UserManager<ApplicationUser>>();

            var adminUser = await userManager.FindByNameAsync("sarancha");

            if (await roleManager.FindByNameAsync("Admin") == null)
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            
            if (await roleManager.FindByNameAsync("Moderator") == null)
                await roleManager.CreateAsync(new IdentityRole("Moderator"));

            if (await roleManager.FindByNameAsync("User") == null)
                await roleManager.CreateAsync(new IdentityRole("User"));

            if (adminUser == null)
            {
                adminUser = new ApplicationUser { Email = "admin@gmail.com", UserName = "admin" };
                await userManager.CreateAsync(adminUser, "123qwe");
            }
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}
