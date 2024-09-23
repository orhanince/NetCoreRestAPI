namespace NetCoreRestAPI.Models
{
    public class BookWithAuthorsDto
    {
        public int Id { get; set; }
        required
        public string Title { get; set; }
        public int? PublishedYear { get; set; }
        public ICollection<BookAuthor>? Authors { get; set; }
        public bool Active { get; set; }
    }
}


