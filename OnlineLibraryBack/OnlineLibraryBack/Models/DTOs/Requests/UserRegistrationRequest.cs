using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.PresentationLayer.Models.DTOs.Requests
{
    public class UserRegistrationRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}