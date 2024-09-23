namespace NetCoreRestAPI.Models
{
    public class AuthorDto
    {
        public int Id { get; set; }
        required
        public string Name { get; set; }
        required
        public string Surname { get; set; }
        public bool Active { get; set; } 
        public Book? Books { get; set; }
    }
}


