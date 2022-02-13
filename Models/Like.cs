using System.ComponentModel.DataAnnotations;

namespace LingvaApp.Models
{
    public class Like
    {
        [Key]
        public int ID { get; set; }
        public int ArticleID { get; set; }
        public string AuthorUsername { get; set; }
    }
}
