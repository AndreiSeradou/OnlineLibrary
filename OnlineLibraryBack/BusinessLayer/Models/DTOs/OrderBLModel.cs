using System;
using OnlineLibrary.DataAccessLayer.Entities;

namespace OnlineLibrary.BusinessLayer.Models.DTOs
{
    public class OrderBLModel
    {
        public int Id { get; set; }
        public bool Condition { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }
    }
}
