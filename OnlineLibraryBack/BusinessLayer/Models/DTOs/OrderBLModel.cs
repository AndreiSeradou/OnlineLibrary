using System;
using DataAccessLayer.Entities;

namespace BusinessLayer.Models.DTOs
{
    public class OrderBLModel
    {
        public int Id { get; set; }
        public bool Condition { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }
    }
}
