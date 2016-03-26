using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using VGGLinkedIn.Data.Migrations;
using VGGLinkedIn.Models;

namespace VGGLinkedIn.Data
{

    public class VggLinkedInContext : IdentityDbContext<User>, IVggLinkedInContext
    {
        public VggLinkedInContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion
                <VggLinkedInContext,
                Configuration>());
        }

        public static VggLinkedInContext Create()
        {
            return new VggLinkedInContext();
        }

        public IDbSet<Post> Post { get; set; }
        public IDbSet<Tag> Tag { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Group>()
            //    .HasRequired(x=>x.Owner)
            //    .WithOptional()
            //    .WillCascadeOnDelete(false);
            //modelBuilder.Entity<Endorcment>()
            //    .HasRequired(x=>x.UserSkill)
            //    .WithMany(x=>x.Endorcements)
            //    .WillCascadeOnDelete(false);
            //modelBuilder.Entity<Experience>()
            //    .HasRequired(x=>x.User)
            //    .WithMany(x=>x.Experiences)
            //    .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }

}
