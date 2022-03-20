using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryBack.Models.DTOs.Requests
{
    public class UserRegistrationRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}