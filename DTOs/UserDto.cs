namespace NetCoreRestAPI.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        required
        public string Username { get; set; }
        required
        public string Email { get; set; }
        required
        public bool Active { get; set; } 
    }
}


