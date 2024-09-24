namespace NetCoreRestAPI.Models
{
    public class BookDto
    {
        public int id { get; set; }
        required
        public string title { get; set; }
        public string? language { get; set; }
        public string? publisher { get; set; }
        public string? isbn { get; set; }
        public string? image { get; set; }
        public int? numberOfPages { get; set; }
        public string? description { get; set; }
        public int? publishedYear { get; set; }
        public List<AuthorDto> authors { get; set; } = new List<AuthorDto>();
        public bool active { get; set; }
    }
}


