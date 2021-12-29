using System;

namespace LingvaApp.Models
{
    public class Task
    {
        public ulong TaskID { get; set; }
        public string LanguageParent { get; set; }
        public int LessonParentID { get; set; }
        public int ThemeParentID { get; set; }
        public string TaskType { get; set; }
        public string TextFieldContent { get; set; }
        public DateTime CreationTimestamp { get; set; }
    }
}
