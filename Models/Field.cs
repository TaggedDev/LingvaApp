using System;

namespace LingvaApp.Models
{
    public class Field
    {
        public int TaskParentID { get; set; }
        public string TaskContent { get; set; }
        public string AnswersAliases { get; set; }
        public DateTime CreationTimestamp { get; set; }
    }
}
