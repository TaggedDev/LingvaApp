using LingvaApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            return RedirectToAction("ChooseTheme", model);
        }

        /// <summary>
        /// Вторая страница создания урока. На странице выпадающее меню (внутри есть вариант "добавить") и 1 кнопка - "выбрать"
        /// </summary>
        /// <param name="model"></param>
        public IActionResult ChooseTheme(Task model)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            ViewBag.IDs = numbers;
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
            return RedirectToAction("ChooseLesson", model);
        }

        /// <summary>
        /// Третья страница создания урока. На ней выпадающее меню с функцией создания нового урока или выбором 
        /// существующего. И кнопка отправки формы.
        /// </summary>
        public IActionResult ChooseLesson(Task model)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            ViewBag.IDs = numbers;
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
            return RedirectToAction("ChooseTaskType", model);
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
        public IActionResult ChooseTaskTypePost(Task model)
        {
            // Add to db and then redirect
            return RedirectToAction("EditTask", model);
        }

        /// <summary>
        /// Пятая, конечная страница урока. Из неё можно попасть в редактирование полей и текста.
        /// </summary>
        public IActionResult EditTask(Task model)
        {
            return View(model);
        }

        /// <summary>
        /// Вызывается при отправке формы. Должна отредактировать сохраненное текстовое поле
        /// </summary>
        [HttpPost("EditTask")]
        public IActionResult EditTaskPost(Task model)
        {
            return View();
        }

        /// <summary>
        /// Шестая, необязательная страница создания урока. Открывает страницу редактирования полей
        /// </summary>
        public IActionResult EditTaskFields(Task model)
        {
            return View();
        }

        /// <summary>
        /// Вызывается по нажатии кнопки "сохранить" в поле для ответов к задаче у задания
        /// </summary>
        [HttpPost("EditTaskFields")]
        public IActionResult EditTaskFieldsPost(Task model)
        {
            return View();
        }

        /// <summary>
        /// Открывает страницу с полем ввода названия темы. 
        /// Вызывается по нажатии кнопки "Новая тема" в LessonCreate/ChooseTheme
        /// </summary>
        public IActionResult NewTheme()
        {
            return View();
        }

        /// <summary>
        /// Вызывается по нажатию кнопки "далее" после ввода названия урока
        /// </summary>
        [HttpPost("NewTheme")]
        public IActionResult NewThemePost(Task model)
        {
            return View();
        }

        /// <summary>
        /// Открывает страницу с полем ввода названия темы. 
        /// Вызывается по нажатии кнопки "Новый урок" в LessonCreate/ChooseLesson
        /// </summary>
        public IActionResult NewLesson()
        {
            return View();
        }

        /// <summary>
        /// Вызывается по нажатию кнопки "далее" после ввода названия урока
        /// </summary>
        [HttpPost("NewLesson")]
        public IActionResult NewLessonPost(Task model)
        {
            return View();
        }
    }
}
