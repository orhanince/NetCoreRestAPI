namespace NetCoreRestAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        required
        public string Username { get; set; }
        required
        public string Email { get; set; }
        required
        public string Password { get; set; } 
        public bool Active { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }
    }
}


