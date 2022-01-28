using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LingvaApp.Models
{
    public class PublishedArticle
    {
        [Key]
        public int ArticleID { get; set; }
        public string AuthorID { get; set; }
        public string AuthorAvatarURL { get; set; }
        public string AuthorUsername { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ThumbnailURL { get; set; }
        [NotMapped]
        public IFormFile ThumbnailPicture { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public string Language { get; set; }
        public string Level { get; set; }
        public string Tags { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
