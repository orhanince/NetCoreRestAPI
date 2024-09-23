namespace NetCoreRestAPI.Models
{
    public class AddBookDto
    {
        required
        public string title { get; set; }
        public int? authorID { get; set; }
    }
}


