using System.Collections.Generic;
using OnlineLibrary.DataAccessLayer.Entities;

namespace OnlineLibrary.BusinessLayer.Models.DTOs
{
    public class BookBLModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int Count { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
