using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Models.DTOs.Requests
{
    public class UpdateOrderRequest
    {
        [Required]
        public int Id { get; set;}
    }
}
