using System;
using System.ComponentModel.DataAnnotations;

namespace LingvaApp.Models
{
    public class Task
    {
        [Key]
        public int TaskID { get; set; }
        public string LanguageParent { get; set; }
        public int LessonParentID { get; set; }
        public int ThemeParentID { get; set; }
        public string TaskType { get; set; }
        public string TextFieldContent { get; set; }
        public DateTime CreationTimestamp { get; set; }
    }
}
