using BlogCMS.Data.Migrations;
using BlogCMS.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace BlogCMS.Data
{
    public class BlogContext : IdentityDbContext<User>
    {
        public BlogContext()
            : base("name=BlogContext", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogContext, Configuration>());
        }

        public static BlogContext Create()
        {
            return new BlogContext();
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}
