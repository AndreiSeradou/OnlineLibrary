using System.Collections.Generic;

namespace OnlineLibraryBack.Configuration
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