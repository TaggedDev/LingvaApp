using LingvaApp.Models;
using System.Collections.Generic;

namespace LingvaApp.ViewModels
{
    public class LanguageViewModel
    {
        public List<Theme> Themes { get; set; }
        public List<Field> Fields { get; set; }
        public List<Task> Tasks { get; set; }
    }
}