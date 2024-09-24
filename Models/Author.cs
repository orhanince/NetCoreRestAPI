namespace NetCoreRestAPI.Models
{
    public class Author
    {
        public int Id { get; set; }
        required
        public string Name { get; set; }
        required
        public string Slug { get; set; }
        public ICollection<BookAuthor>? BookAuthors { get; set; }
        public bool Active { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }
    }
}


