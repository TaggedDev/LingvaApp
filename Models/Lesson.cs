using System;

namespace LingvaApp.Models
{
    public class Lesson
    {
        public int LessonID { get; set; }
        public int ThemeParentID { get; set; }
        public string LanguageParent { get; set; }
        public string LessonTitle { get; set; }
        public DateTime CreationTimestamp { get; set; }
    }
}
