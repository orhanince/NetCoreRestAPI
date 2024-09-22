namespace NetCoreRestAPI.Models
{
    public class Language
    {
        public int Id { get; set; }
        required
        public string Key { get; set; }
        required
        public string Name { get; set; }
        public ICollection<Book>? Books { get; set; } // Navigation property
        public bool Active { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }
    }
}


