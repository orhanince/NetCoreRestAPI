namespace NetCoreRestAPI.Models
{
    public class AddBookDto
    {
        required
        public string title { get; set; }
        public bool active { get; set; } = true;
        public string? image { get; set; }
        public string? isbn { get; set; }
        public string? description { get; set; }
        public int? numberOfPages { get; set; }
        public int? authorId { get; set; }
        public int? languageId { get; set; }
        public int? publisherId { get; set; }
        public string? publishedDate { get; set; }
        
    }
}


