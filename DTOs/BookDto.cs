namespace NetCoreRestAPI.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        required
        public string Title { get; set; }
        public string? language { get; set; }
        public string? publisher { get; set; }
        public int? PublishedYear { get; set; }
        //public ICollection<BookAuthor>? BookAuthors { get; set; }
        public List<AuthorDto> Authors { get; set; } = new List<AuthorDto>();
        public bool Active { get; set; }
    }
}


