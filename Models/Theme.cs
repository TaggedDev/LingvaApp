using System;
using System.ComponentModel.DataAnnotations;

namespace LingvaApp.Models
{
    public class Theme
    {
        [Key]
        public int ThemeID { get; set; }
        public int LanguageLevelColumnPosition { get; set; }
        public string LanguageParent { get; set; }
        public string ThemeLanguageLevel { get; set; }
        public string ThemeTopic { get; set; }
        public DateTime CreationTimestamp { get; set; }
    }
}
