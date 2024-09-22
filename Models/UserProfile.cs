using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NetCoreRestAPI.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePicture { get; set; }
        public User? User { get; set; } // Navigation property
        public bool Active { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }
    }
}


