using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LingvaApp.Models
{
    public class PendingArticle
    {
        [Key]
        public int ArticleID { get; set; }
        public string AuthorID { get; set; }
        public string AuthorAvatarURL { get; set; }
        public string AuthorUsername { get; set; }
        [Required(ErrorMessage = "Название должно быть указано")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Описание должно быть заполнено")]
        public string Description { get; set; }
        public string ThumbnailURL { get; set; }
        [NotMapped]
        public IFormFile ThumbnailPicture { get; set; }
        [Required(ErrorMessage = "Содержание статьи должно быть длиннее 10 символов")]
        [MinLength(10)]
        public string Content { get; set; }
        [Required(ErrorMessage = "Выберите язык из выпадающего списка")]
        public string Language { get; set; }
        [Required(ErrorMessage = "Выберите уровень из выпадающего списка")]
        public string Level { get; set; }
        [Required(ErrorMessage = "Укажите несколько тегов")]
        public string Tags { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
