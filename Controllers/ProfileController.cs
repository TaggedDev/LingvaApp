using LingvaApp.Data;
using LingvaApp.Models;
using LingvaApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LingvaApp.Controllers
{
    public class ProfileController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _dbContext;

        public ProfileController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult Register() => View();


        [HttpGet]
        public IActionResult Check() => View();


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser { Email = model.Email, UserName = model.UserName, BannerURL = "default_banner.jpg", AvatarURL = "default_avatar.png" };
                // добавляем пользователя
                string errorMessage = string.Empty;
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Intro");
                }
                else
                {
                    foreach (var error in result.Errors)
                        errorMessage = errorMessage + error.Description + '\n';
                }
                ViewBag.ErrorMessage = errorMessage;
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null) => View(new LoginViewModel { ReturnUrl = returnUrl });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl)) // проверяем, принадлежит ли URL приложению
                            return Redirect(model.ReturnUrl);
                        else
                            return RedirectToAction("", "");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Учетной записи с такой электронной почтой не существует");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Route("Profile/")]
        [Route("Profile/0")]
        [Route("Profile/self")]
        public async Task<IActionResult> Index()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            return View(user);
        }

        [Route("Profile/{name}")]
        public async Task<IActionResult> Index(string name)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(name);
            return View(user);
        }

        
    }
}