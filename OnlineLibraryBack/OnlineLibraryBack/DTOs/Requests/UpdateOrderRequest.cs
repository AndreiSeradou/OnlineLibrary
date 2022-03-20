using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryBack.Models.DTOs.Requests
{
    public class UpdateOrderRequest
    {
        [Required]
        public int Id { get; set;}
    }
}
