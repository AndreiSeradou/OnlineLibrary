using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Models.DTOs.Requests
{
    public class OrderRequest
    {
        [Required]
        public int BookId { get; set; }
    }
}
