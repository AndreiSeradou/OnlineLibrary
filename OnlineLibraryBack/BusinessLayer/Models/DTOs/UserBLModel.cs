using System.Collections.Generic;
using OnlineLibrary.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;

namespace OnlineLibrary.BusinessLayer.Models.DTOs
{
    public class UserBLModel : IdentityUser
    {
        public ICollection<Order> Orders { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
