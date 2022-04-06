using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLibrary.DataAccessLayer.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public bool Condition { get; set; }
        public DateTime DateTimeCreated { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }
        public string UserId { get;set; }
        public int BookId { get; set; }
    }
}
