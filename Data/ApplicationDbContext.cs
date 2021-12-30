using LingvaApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LingvaApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Field> Field { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
