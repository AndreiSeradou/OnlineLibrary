using System;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Models.DTOs
{
    public class OrderEntityModel
    {
        public int Id { get; set; }
        public bool Condition { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }
    }
}
