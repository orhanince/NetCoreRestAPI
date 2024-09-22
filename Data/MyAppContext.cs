using Microsoft.EntityFrameworkCore;
using NetCoreRestAPI.Models;

namespace NetCoreRestAPI.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserProfile)
                .WithOne(p => p.User)
                .HasForeignKey<UserProfile>(p => p.UserId);
        }

        public DbSet<User> Users { get; set; } // Users table
         public DbSet<UserProfile> UserProfiles { get; set; } // UserProfile table
    }
}