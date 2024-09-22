namespace NetCoreRestAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        required
        public string Title { get; set; }
        public int? LanguageId { get; set; }
        public int? PublisherId { get; set; }
        public Language? Language { get; set; } // Navigation property
        public Publisher? Publisher { get; set; } // Navigation property
        public bool Active { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }
    }
}


