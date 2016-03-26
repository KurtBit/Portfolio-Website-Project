using VGGLinkedIn.Models;

namespace VGGLinkedIn.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<VggLinkedInContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(VggLinkedInContext context)
        {
#if true
            //var Users = new[]
            //{
            //    new User() {},
            //};
#endif
        }
    }
}
