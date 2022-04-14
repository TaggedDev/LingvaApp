using LingvaApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LingvaApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Like> Likes { get; set; } //I made this comment to create a commit in order to participate. I will make normal changes later on
        public DbSet<PublishedArticle> PublishedArticles { get; set; }
        public DbSet<PendingArticle> PendingArticles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { base.OnModelCreating(modelBuilder); }
    }
}
