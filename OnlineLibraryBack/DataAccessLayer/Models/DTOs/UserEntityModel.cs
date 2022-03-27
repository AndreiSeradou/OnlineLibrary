using System.Collections.Generic;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Models.DTOs
{
    public class UserEntityModel : IdentityUser
    {
        public ICollection<Order> Orders { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
