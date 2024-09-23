namespace NetCoreRestAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        required
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? ISBN { get; set; }
        public int? NumberOfPages { get; set; }
        public int? LanguageId { get; set; }
        public int? PublisherId { get; set; }
        public Language? Language { get; set; }
        public Publisher? Publisher { get; set; }
        public int? PublishedYear { get; set; }
        public ICollection<BookAuthor>? BookAuthors { get; set; }
        public bool Active { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }
    }
}


