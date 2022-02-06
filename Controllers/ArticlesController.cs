using LingvaApp.Data;
using LingvaApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace LingvaApp.Controllers
{
    public class ArticlesController : Controller
    {
        private ApplicationDbContext _dbContext;
        private UserManager<ApplicationUser> _userManager;
        private IWebHostEnvironment _appEnvironment;

        public ArticlesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment appEnvironment)
        {
            _dbContext = context;
            _userManager = userManager;
            _appEnvironment = appEnvironment;
        }

        /* == VIEWS == */

        /// <summary> 
        /// Calls when invalid id of article is passed
        /// </summary>
        public IActionResult Error() => View();

        /// <summary>
        /// Main page with newest articles
        /// </summary>
        [Route("Articles/Feed")]
        [Route("Articles/Home")]
        [Route("Articles/")]
        public IActionResult Feed()
        {
            List<PublishedArticle> articles = _dbContext.PublishedArticles.ToList();
            return View(articles);
        }

        /// <summary>
        /// A page with WYTIWYG
        /// </summary>
        [Route("Articles/New")]
        [Route("Articles/Create")]
        public IActionResult Create() => View();

        /// <summary>
        /// Opens a list of all articles that are pending. Starting from oldest to newest
        /// </summary
        public IActionResult Pendings()
        {
            /*List<PendingArticle> pendings = _dbContext.PendingArticles.OrderBy(x => x.CreationDate).ToList();*/
            List<PendingArticle> pendings = _dbContext.PendingArticles.ToList();
            return View(pendings);
        }

        /// <summary>
        /// Actually opens a pending article by its ID
        /// </summary>
        public IActionResult PendingArticle(int id)
        {
            var model = _dbContext.PendingArticles.FirstOrDefault(m => m.ArticleID == id);
            if (model is null)
                return RedirectToAction("Error");
            return View(model);
        }

        /// <summary>
        /// Opens published article page by id
        /// </summary>
        /// <param name="id"></param>
        public IActionResult Article(int id)
        {
            var model = _dbContext.PublishedArticles.FirstOrDefault(m => m.ArticleID == id);
            if (model is null)
            {
                string line = model.ArticleID.ToString();
                return RedirectToAction("Error", line);
            }
            return View(model);
        }

        /* == VIEWS END == */

        /* == == == == == == == == == */

        /* == FORMS HANDLERS == */

        /// <summary>
        /// Calls on 'create article' form and adds to pending articles
        /// </summary>
        [HttpPost("Articles/Create")]
        public async Task<IActionResult> CreatePost(PendingArticle model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    string path;
                    if (model.ThumbnailPicture != null)
                    {
                        path = @$"/files/ArticleThumbnails/{DateTime.Now.ToString("MM-dd-yyyy--HH-mm-tt")}-{model.ThumbnailPicture.FileName}";
                        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                        {
                            await model.ThumbnailPicture.CopyToAsync(fileStream);
                        }
                        model.ThumbnailURL = path;
                    }
                    model.CreationDate = DateTime.Now;
                    model.AuthorID = user.Id;
                    model.AuthorAvatarURL = user.AvatarURL;
                    await _dbContext.PendingArticles.AddAsync(model);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("Feed");
                }
                else
                {
                    ModelState.AddModelError("", "Вы не авторизованы");
                }
            }
            return View("Create", model);
        }

        /* == FORMS HANDLERS END == */

        /* == == == == == == == == == */

        /* == BUTTONS HANLDERS == */

        /// <summary>
        /// Called on 'V' button in Pending list
        /// </summary>
        public IActionResult OnApproveButtonPressed(int id)
        {
            ApprovePendingArticle(id);
            return new JsonResult("");
        }

        /// <summary>
        /// Called on 'X' button in Pending list
        /// </summary>
        public IActionResult OnDeleteButtonPressed(int id)
        {
            DeletePendingArticle(id);
            return new JsonResult("");
        }

        public IActionResult ReturnFilteredArticles(string language, string level, string author, string tags, string keywords)
        {
            List<PublishedArticle> result = _dbContext.PublishedArticles.Where(m => m.Level == "A2").ToList();
            return new JsonResult(result);
        }

        /* == BUTTON HANLDERS END == */

        /* == == == == == == == == == */

        /* == MISCALANIOUS FUNCTIONS == */

        /// <summary>
        /// Moves item from Pending to published list
        /// </summary>
        public async void ApprovePendingArticle(int id)
        {
            var article = _dbContext.PendingArticles.First(m => m.ArticleID == id);
            _dbContext.PublishedArticles.Add(ConvertPendingToPublish(article));
            _dbContext.PendingArticles.Remove(article);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes pending article from pending table by id
        /// </summary>
        public async void DeletePendingArticle(int id)
        {
            var article = _dbContext.PendingArticles.First(m => m.ArticleID == id);
            _dbContext.PendingArticles.Remove(article);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Converts Pending article class to Published
        /// </summary>
        /// <param name="income">Pending article item object</param>
        /// <returns>Saved parameters published article object</returns>
        public PublishedArticle ConvertPendingToPublish(PendingArticle income) => new PublishedArticle
        {
            AuthorID = income.AuthorID,
            AuthorUsername = income.AuthorUsername,
            AuthorAvatarURL = income.AuthorAvatarURL,
            Title = income.Title,
            Description = income.Description,
            ThumbnailURL = income.ThumbnailURL,
            Content = income.Content,
            Language = income.Language,
            Level = income.Level,
            Tags = income.Tags,
            Rating = 0,
            CreationDate = DateTime.Now
        };
    }
}
