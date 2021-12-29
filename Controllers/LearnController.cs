using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LingvaApp.Controllers
{
    public class LearnController : Controller
    {
        public IActionResult Index() => View();
        
    }
}
