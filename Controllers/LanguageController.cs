using LingvaApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LingvaApp.Controllers
{
    public class LanguageController : Controller
    {
        public IActionResult English()
        {
            Task lesson = new Task();
            return View(lesson);
        }

        public IActionResult Russian()
        {
            Task lesson = new Task();
            return View(lesson);
        }

        public IActionResult Deutch()
        {
            Task lesson = new Task();
            return View(lesson);
        }
    }
}
