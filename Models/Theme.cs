using System;

namespace LingvaApp.Models
{
    public class Theme
    {
        public ulong ThemeID { get; set; }
        public string LanguageParent { get; set; }
        public string ThemeLanguageLevel { get; set; }
        public string ThemeTopic { get; set; }
        public DateTime CreationTimestamp { get; set; }
    }
}
