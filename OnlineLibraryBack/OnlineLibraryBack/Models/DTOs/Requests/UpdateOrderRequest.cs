using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.PresentationLayer.Models.DTOs.Requests
{
    public class UpdateOrderRequest
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int Id { get; set;}
    }
}
