using LingvaApp.Data;
using LingvaApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LingvaApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;

        public ProfileController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _dbContext = context;
        }

        public async System.Threading.Tasks.Task<IActionResult> Index(string name)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(name);
            return View(user);
        }
    }
}