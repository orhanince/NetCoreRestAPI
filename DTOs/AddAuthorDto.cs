namespace NetCoreRestAPI.Models
{
    public class AddAuthorDto
    {

        required
        public string name { get; set; }
        public string? image { get; set; }
        public string? about { get; set; }

    }
}


