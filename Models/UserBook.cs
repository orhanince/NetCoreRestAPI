namespace NetCoreRestAPI.Models
{
    public class UserBook
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        required
        public User User { get; set; }
        public int BookId { get; set; }
        required
        public Book Book { get; set; }
    }
}


