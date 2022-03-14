using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Models.DTOs.Requests
{
    public class BookRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public int Count { get; set; }
    }
}
