using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public bool Condition { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }
    }
}
