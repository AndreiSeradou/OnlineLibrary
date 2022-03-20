using System;
using System.Collections.Generic;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Models.DTOs
{
    public class BookEntityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int Count { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
