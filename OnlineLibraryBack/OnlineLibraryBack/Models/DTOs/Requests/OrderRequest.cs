using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.PresentationLayer.Models.DTOs.Requests
{
    public class OrderRequest
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int BookId { get; set; }
    }
}
