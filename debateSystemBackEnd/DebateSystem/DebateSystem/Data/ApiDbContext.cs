using DebateSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace DebateSystem.Data
{
    public class ApiDbContext:DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options):base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<TopicCategory> TopicCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //specify unique 
            modelBuilder.Entity<ApplicationUser>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<ApplicationUser>().HasIndex(u => u.UserName).IsUnique();
            modelBuilder.Entity<Topic>().HasIndex(u => u.TopicName).IsUnique();
            modelBuilder.Entity<TopicCategory>().HasIndex(u => u.CategoryName).IsUnique();

        }
    }
}
