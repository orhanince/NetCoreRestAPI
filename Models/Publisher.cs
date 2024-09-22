namespace NetCoreRestAPI.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        required
        public string Name { get; set; }
        public string? Logo { get; set; }
        public string? About { get; set; }
        public ICollection<Book>? Books { get; set; } // Navigation property
        public bool Active { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }
    }
}


