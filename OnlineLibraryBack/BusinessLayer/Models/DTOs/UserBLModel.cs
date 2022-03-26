using System.Collections.Generic;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;

namespace BusinessLayer.Models.DTOs
{
    public class UserBLModel : IdentityUser
    {
        public ICollection<Order> Orders { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
