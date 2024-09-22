namespace NetCoreRestAPI.Models
{
    public class BookAuthor
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        required
        public Book Book { get; set; }
        public int AuthorId { get; set; }
        required
        public Author Author { get; set; }
    }
}


