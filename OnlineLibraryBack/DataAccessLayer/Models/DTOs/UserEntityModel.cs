using System.Collections.Generic;
using OnlineLibrary.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;

namespace OnlineLibrary.DataAccessLayer.Models.DTOs
{
    public class UserEntityModel : IdentityUser
    {
        public ICollection<Order> Orders { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
