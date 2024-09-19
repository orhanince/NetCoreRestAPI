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

        public DbSet<User> Users { get; set; } // Users table
    }
}