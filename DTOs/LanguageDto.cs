namespace NetCoreRestAPI.Models
{
    public class LanguageDto
    {
        public int Id { get; set; }
        required
        public string Key { get; set; }
        required
        public string Name { get; set; }
        required
        public bool Active { get; set; } 
    }
}


