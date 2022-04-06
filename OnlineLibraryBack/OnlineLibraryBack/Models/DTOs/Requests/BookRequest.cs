using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.PresentationLayer.Models.DTOs.Requests
{
    public class BookRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int Count { get; set; }
    }
}
