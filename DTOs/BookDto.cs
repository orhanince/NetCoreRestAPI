namespace NetCoreRestAPI.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        required
        public string Title { get; set; }
        public int? PublishedYear { get; set; }
        public ICollection<BookAuthor>? BookAuthors { get; set; }
        public bool Active { get; set; }
    }
}


