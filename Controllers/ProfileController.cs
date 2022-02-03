using LingvaApp.Data;
using LingvaApp.Models;
using LingvaApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UploadImage()
        {
            var model = _dbContext.UploadedImages.ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(UploadedImageViewModel model)
        {
            UploadedImage image = new UploadedImage();
            image.Name = model.Name;
            image.OwnerID = _userManager.GetUserAsync(User).Result.Id;

            if (model.Image != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(model.Image.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)model.Image.Length);
                }
                image.Image = imageData;
                image.CreationDate = DateTime.Now;
            }

            _dbContext.UploadedImages.Add(image);
            await _dbContext.SaveChangesAsync();

            return View(_dbContext.UploadedImages.ToList());
        }

        public IActionResult OnDeleteButtonPressed(int id)
        {
            return new JsonResult("");
        }

        public IActionResult GetUploadedImagesAsync()
        {
            ApplicationUser user = _userManager.GetUserAsync(User).Result;
            var result = _dbContext.UploadedImages.Where(x => x.OwnerID == user.Id).ToString();
            return new JsonResult(result);
        }
    }
}