using System.Collections.Generic;

namespace OnlineLibrary.PresentationLayer.Models.DTOs.Responses
{
    public class AuthResult
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}