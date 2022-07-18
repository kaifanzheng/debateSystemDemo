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
        public DbSet<TopicTag> TopicTags { get; set; }
        public DbSet<WrittenArgument> WrittenArguments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //specify unique 
            modelBuilder.Entity<ApplicationUser>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<ApplicationUser>().HasIndex(u => u.UserName).IsUnique();
            modelBuilder.Entity<Topic>().HasIndex(u => u.TopicName).IsUnique();
            modelBuilder.Entity<TopicTag>().HasIndex(u => u.Name).IsUnique();

        }
    }
}
