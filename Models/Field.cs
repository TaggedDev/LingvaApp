using System;
using System.ComponentModel.DataAnnotations;

namespace LingvaApp.Models
{
    public class Field
    {
        [Key]
        public int FieldID { get; set; }
        public int TaskParentID { get; set; }
        public string TaskContent { get; set; }
        public string AnswersAliases { get; set; }
        public DateTime CreationTimestamp { get; set; }
    }
}
