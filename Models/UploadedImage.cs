using System.ComponentModel.DataAnnotations;

namespace LingvaApp.Models
{
    public class UploadedImage
    {
        [Key]
        public int ID { get; set; }
        public string OwnerID { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
    }
}