using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryBack.Models.DTOs.Requests
{
    public class OrderRequest
    {
        [Required]
        public int BookId { get; set; }
    }
}
