using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StephenKingFanSite.Models
{
    public class ForumContext : IdentityDbContext
    {
        public ForumContext(
            DbContextOptions<ForumContext> options)
            : base(options) { }

        public DbSet<ForumPost> ForumPosts { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Novel> Novels { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Scores> Scores { get; set; }

    }
}
