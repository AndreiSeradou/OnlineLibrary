namespace OnlineLibraryBack.Models.DTOs.Responses
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public bool Condition { get; set; }
        public BookResponse Book { get; set; }
        public UserResponse User { get; set; }
    }
}
