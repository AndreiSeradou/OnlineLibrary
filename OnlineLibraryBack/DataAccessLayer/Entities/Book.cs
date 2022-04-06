using System.Collections.Generic;

namespace OnlineLibrary.DataAccessLayer.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int Count { get; set; }
        public ICollection<User> Users { get; set; }
    }
}