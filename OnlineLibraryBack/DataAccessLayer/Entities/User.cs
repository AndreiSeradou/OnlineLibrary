using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class User :IdentityUser
    {
        public int Id { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
