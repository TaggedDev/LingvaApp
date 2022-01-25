using LingvaApp.Data;
using LingvaApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;

namespace LingvaApp.Controllers
{
    public class ArticlesController : Controller
    {
        private ApplicationDbContext _dbContext;
        private UserManager<IdentityUser> _userManager;

        public ArticlesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _dbContext = context;
            _userManager = userManager;
        }

        [Route("Articles/Feed")]
        [Route("Articles/Home")]
        [Route("Articles/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Articles/New")]
        [Route("Articles/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async System.Threading.Tasks.Task<IActionResult> CreatePostAsync(PendingArticle model)
        {
            IdentityUser user = await _userManager.GetUserAsync(User);
            model.CreationDate = DateTime.Now;
            model.AuthorID = user.Id;
            await _dbContext.PendingArticles.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Create");
        }


        public IActionResult Pending()
        {
            List<PendingArticle> pendings = _dbContext.PendingArticles.OrderBy(x => x.CreationDate).ToList();
            return View(pendings);
        }
    }
}
