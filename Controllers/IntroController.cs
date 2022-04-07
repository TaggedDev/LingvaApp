using Microsoft.AspNetCore.Mvc;

namespace LingvaApp.Controllers
{
    public class IntroController : Controller
    {
        public IActionResult Index() => RedirectToAction("Feed", "Articles");
    }
}
