using LingvaApp.Data;
using LingvaApp.Models;
using LingvaApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LingvaApp.Controllers
{
    /// <summary>
    /// Класс управляет системой создания и добавления уроков в базу данных
    /// </summary>
    public class LessonCreateController : Controller
    {
        /* Методы, возвращающие IActionResult попарно разбиты. 
         * Методы с атрибутом HttpPost вызываются по нажатии на кнопку отправки формы
         * Методы без атрибута приравниваются к атрибуту HttpGet и вызываются при 
         * вызове самой страницы. 
         * Задача класса - пошагово создать урок, сохраняя промежуточный результат в базу данных */

        private ApplicationDbContext _dbContext;

        public LessonCreateController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        /// Первая стартовая страницы создания урока. На странице 3 радиокнопки с выбором языка
        /// </summary>
        public IActionResult ChooseLanguage() => View();

        /// <summary>
        /// Вызывается по нажатии на кнопку отправки формы в LessonCreate/ChooseLanguage.
        /// </summary>
        /// <param name="model">Объект модели с заполненным LanguageParent</param>
        [HttpPost("ChooseLanguage")]
        public IActionResult ChooseLanguage(Task model)
        {
            // Add to database then redirect
            List<string> langs = new List<string>() { "Deutsch", "English", "Русский" };
            if (langs.Contains(model.LanguageParent))
            { 
                return RedirectToAction("ChooseTheme", model);
            }
            else
            {
                ViewBag.ErrorMessage = "Значеня урока не распознано";
                return View("ChooseLanguage", model);
            }
        }

        /// <summary>
        /// Вторая страница создания урока. На странице выпадающее меню (внутри есть вариант "добавить") и 1 кнопка - "выбрать"
        /// </summary>
        public IActionResult ChooseTheme(Task model)
        {
            var themes = _dbContext.Themes.Where(x => x.LanguageParent == model.LanguageParent).ToList();
            ViewBag.themes = themes;
            return View(model);
        }

        /// <summary>
        /// Вызывается по нажатии на кнопку отправки формы в LessonCreate/ChooseTheme
        /// </summary>
        /// <param name="model">Объект модели с заполненным полем ThemeParentID</param>
        [HttpPost("ChooseTheme")]
        public IActionResult ChooseThemePost(Task model)
        {
            // Add to db and then redirect
            if (model.ThemeParentID == 0)
            {
                TaskTheme newModel = new TaskTheme() { Task = model, Theme = new Theme() };
                return View("NewTheme", newModel);
            }
            else
            {
                return RedirectToAction("ChooseLesson", model);
            }
        }

        /// <summary>
        /// Третья страница создания урока. На ней выпадающее меню с функцией создания нового урока или выбором 
        /// существующего. И кнопка отправки формы.
        /// </summary>
        public IActionResult ChooseLesson(Task model)
        {
            var lessons = _dbContext.Lessons.Where(x => x.ThemeParentID == model.ThemeParentID).ToList();
            ViewBag.lessons = lessons;
            return View(model);
        }

        /// <summary>
        /// Вызывается при отправке формы третьего урока в LessonCreate/ChooseTask
        /// </summary>
        /// <param name="model">Заполненная модель с LessonParentID</param>
        [HttpPost("ChooseLesson")]
        public IActionResult ChooseLessonPost(Task model)
        {
            // Add to db
            if (model.LessonParentID == 0)
            {
                TaskLesson newModel = new TaskLesson() { Task = model, Lesson = new Lesson() };
                return View("NewLesson", newModel);
            }
            else
            {
                return RedirectToAction("ChooseTask", model);
            }
        }

        /// <summary>
        /// Четвертое поле, вызывается после выбора "Урока" для выбора задания. Т.е. ред. существующего или создания нового
        /// </summary>
        public IActionResult ChooseTask(Task model)
        {
            var tasks = _dbContext.Tasks.Where(x => (x.ThemeParentID == model.ThemeParentID) && (x.LessonParentID == model.ThemeParentID)).ToList();
            ViewBag.tasks = tasks;
            return View(model);
        }
        
        /// <summary>
        /// Вызывается по выбору задания, 0 = новое задание
        /// </summary>
        [HttpPost("ChooseTask")]
        public IActionResult ChooseTaskPost(Task model)
        {
            if (model.TaskID == 0)
            {
                // Redirect to task type selection page
                return RedirectToAction("ChooseTaskType", model);
            }
            else
            {
                // Edit existing task
                model.TaskType = _dbContext.Tasks.Where(x => x.TaskID == model.TaskID).FirstOrDefault().TaskType;
                return RedirectToAction("EditTask", model);
            }
        }

        /// <summary>
        /// Четвёртая страница создания урока. На странице радиокнопки с типом задания, радиокнопки с типом наличия текста
        /// и кнопка "далее", отправляющая данные в форму
        /// </summary>
        public IActionResult ChooseTaskType(Task model) => View(model);

        /// <summary>
        /// Вызывается при отправке формы в LessonCreate/ChooseTaskType
        /// </summary>
        /// <param name="model">Модель с заполненным полем LessonType</param>
        [HttpPost("ChooseTaskType")]
        public async System.Threading.Tasks.Task<IActionResult> ChooseTaskTypePostAsync(Task model)
        {
            // Add to db and then redirect
            model.CreationTimestamp = DateTime.Now;
            _dbContext.Tasks.Add(model);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("EditTask", model);
        }

        /// <summary>
        /// Пятая, конечная страница урока. Из неё можно попасть в редактирование полей и текста.
        /// </summary>
        public IActionResult EditTask(Task model) => View(model);
        
        /// <summary>
        /// Вызывается при отправке формы. Должна отредактировать сохраненное текстовое поле
        /// </summary>
        [HttpPost("EditTask")]
        public async System.Threading.Tasks.Task<IActionResult> EditTaskPostAsync(Task model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return View("EditTask", model);
        }

        /// <summary>
        /// Шестая, необязательная страница создания урока. Открывает страницу редактирования полей
        /// </summary>
        public IActionResult EditTaskFields(Task model) => View();
        

        /// <summary>
        /// Вызывается по нажатии кнопки "сохранить" в поле для ответов к задаче у задания
        /// </summary>
        [HttpPost("EditTaskFields")]
        public IActionResult EditTaskFieldsPost(Task model) { return View("EditTaskFields"); }

        /// <summary>
        /// Открывает страницу с полем ввода названия темы. 
        /// Вызывается по нажатии кнопки "Новая тема" в LessonCreate/ChooseTheme
        /// </summary>
            public IActionResult NewTheme(TaskTheme model) => View();

        /// <summary>
        /// Вызывается по нажатию кнопки "далее" после ввода названия урока
        /// </summary>
        [HttpPost("NewTheme")]
        public async System.Threading.Tasks.Task<IActionResult> NewThemePostAsync(TaskTheme model)
        {
            Theme theme = model.Theme;
            theme.CreationTimestamp = DateTime.Now;
            theme.LanguageParent = model.Task.LanguageParent;
            
            _dbContext.Themes.Add(theme);
            await _dbContext.SaveChangesAsync();

            Task taskModel = model.Task;
            taskModel.ThemeParentID = theme.ThemeID;

            return RedirectToAction("ChooseLesson", taskModel);
        }

        /// <summary>
        /// Открывает страницу с полем ввода названия темы. 
        /// Вызывается по нажатии кнопки "Новый урок" в LessonCreate/ChooseLesson
        /// </summary>
        public IActionResult NewLesson(TaskLesson model) => View(model);
        

        /// <summary>
        /// Вызывается по нажатию кнопки "далее" после ввода названия урока
        /// </summary>
        [HttpPost("NewLesson")]
        public async System.Threading.Tasks.Task<IActionResult> NewLessonPostAsync(TaskLesson model)
        {
            Lesson lesson = model.Lesson;
            Task task = model.Task;
            lesson.CreationTimestamp = DateTime.Now;
            lesson.LanguageParent = task.LanguageParent;
            lesson.ThemeParentID = task.ThemeParentID;

            _dbContext.Lessons.Add(lesson);
            await _dbContext.SaveChangesAsync();

            task.LessonParentID = lesson.LessonID;

            return RedirectToAction("ChooseTaskType", task);
        }
    }
}
