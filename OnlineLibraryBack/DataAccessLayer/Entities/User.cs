using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace OnlineLibrary.DataAccessLayer.Entities
{
    public class User : IdentityUser
    {
        public ICollection<Order> Orders { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
