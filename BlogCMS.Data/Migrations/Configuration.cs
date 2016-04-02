using System.Data.Entity.Migrations;
using BlogCMS.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlogCMS.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BlogCMS.Data.BlogContext>
    {
        
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BlogContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<User>(new UserStore<User>(context));

            string[] roles = new[] { "Owner", "Admin", "User" };

            foreach (var role in roles)
            {
                if (!roleManager.RoleExists(role))
                {
                    roleManager.Create(new IdentityRole(role));
                }
            }

            var user = new User()
            {
                Id = "2c746f9d - 36ef - 4a9b - 890a - b58efb498b93",
                AvatarUrl = "/Content/images/avatar.png",
                Email = "petromilpavlov@gmail.com",
                PasswordHash = "ADrCMimJIJXqi75kpcwjShbHn79 + g2YR0skj74D4GSLcGS5Ut / Fis6jgCmlf7 + R5Yw ==",
                SecurityStamp = "adbf4e0b-2f65-4ee3-ace4-0279081adce1",
                LockoutEnabled = true,
                UserName = "petromilpavlov@gmail.com",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                AccessFailedCount = 0,
                Role = "Owner"
            };
            context.Users.AddOrUpdate(user);
            context.SaveChanges();
            userManager.AddToRole(user.Id, roles[0]);
        }
    }
}
