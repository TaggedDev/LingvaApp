using LingvaApp.Data;
using LingvaApp.Models;
using LingvaApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LingvaApp.Controllers
{
    public class LanguageController : Controller
    {
        private ApplicationDbContext _dbContext;

        public LanguageController(ApplicationDbContext context)
        {
            _dbContext = context;
        }


        public IActionResult English()
        {
            LanguageViewModel viewmodel = new LanguageViewModel()
            {
                Themes = _dbContext.Themes.Where(x => x.LanguageParent == "English").ToList()
            };
            return View(viewmodel);
        }

        public IActionResult Russian()
        {
            LanguageViewModel viewmodel = new LanguageViewModel()
            {
                Themes = _dbContext.Themes.Where(x => x.LanguageParent == "Русский").ToList()
            };
            return View(viewmodel);
        }

        public IActionResult Deutsch()
        {
            LanguageViewModel viewmodel = new LanguageViewModel()
            {
                Themes = _dbContext.Themes.Where(x => x.LanguageParent == "Deutsch").ToList()
            };
            return View(viewmodel);
        }
    
        public IActionResult Lesson(int theme, int taskid)
        {
            // If task id == 0, it should load first element. Else - load fields by taskId
            ViewBag.LoadId = taskid;
            ThemeViewModel model = new ThemeViewModel(_dbContext, theme);
            if (taskid == 0)
            {
                ViewBag.LoadId = model.Tasks[0].TaskID;
                ViewBag.Fields = model.Fields[0];
                return View(model);
            }
            else
            {
                foreach (List<Field> field in model.Fields)
                {
                    if (field[0].TaskParentID == taskid)
                    {
                        ViewBag.Fields = field;
                        return View(model);
                    }       
                }
                ViewBag.Fields = new List<Field>();
                return View(model);
            }
        }
    }
}
