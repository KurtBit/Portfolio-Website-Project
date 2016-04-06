using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using BlogCMS.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlogCMS.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BlogContext>
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
                Role = "Owner",
                AboutMe = @"I generally have no problem with the Bootstrap 
                v.3 and the Telerik bootstrap theme working together. 
                The key exception in my case is the  form - control class. 
                For example the controls (drop-downs, auto-completes, etc) 
                do not wrap below the label as expected on a standard (non-horizontal) form.",
                FullName = "Petromil Pavlov"
            };
            context.Users.AddOrUpdate(user);
            context.SaveChanges();
            userManager.AddToRole(user.Id, roles[0]);

            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Content = @"Lorem ipsum dolor sit amet,
                        consectetur adipiscing elit,
                        sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
                        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                        Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.
                        Excepteur sint occaecat cupidatat non proident,
                        sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    CreatedAt = DateTime.Now,
                    IsDeleted = 0,
                    Title = "First Post",
                    Slug = "#Programming, #Telerik",
                    UserId = user.Id
                },
                new Post()
                {
                    Content = @"On the other hand,we denounce with righteous indignation and dislike men who are so beguiled and
                        demoralized by the charms of pleasure of the moment,so blinded by desire,
                        that they cannot foresee the pain and trouble that are bound to ensue; 
                        and equal blame belongs to those who fail in their duty through weakness of will, 
                        which is the same as saying through shrinking from toil and pain.These cases are perfectly 
                        simple and easy to distinguish. In a free hour, when our power of choice is untrammelled 
                        and when nothing prevents our being able to do what we like best, every pleasure is to 
                        be welcomed and every pain avoided. But in certain circumstances and owing to the claims 
                        of duty or the obligations of business it will frequently occur that pleasures have to 
                        be repudiated and annoyances accepted.The wise man therefore always holds in these matters 
                        to this principle of selection: he rejects pleasures to secure other greater pleasures, 
                        or else he endures pains to avoid worse pains.",
                    CreatedAt = DateTime.Now,
                    IsDeleted = 0,
                    Title = "Second Post",
                    Slug = "#Programming, #Telerik",
                    UserId = user.Id
                }
            };
            foreach (var post in posts)
            {
                context.Posts.AddOrUpdate(post);
            }
            context.SaveChanges();

            var owner = new Owner()
            {
                AboutMe = @"I generally have no problem with the Bootstrap 
                v.3 and the Telerik bootstrap theme working together. 
                The key exception in my case is the  form - control class. 
                For example the controls (drop-downs, auto-completes, etc) 
                do not wrap below the label as expected on a standard (non-horizontal) form.",
                UserId = user.Id,
                AvatarUrl = "/Content/images/avatar.png"
            };
            context.Owner.AddOrUpdate(owner);
            context.SaveChanges();

            //var timeSpan = new DateTime(2016, 8, 27).Subtract(new DateTime(2015, 11, 27));

            List<Project> projects = new List<Project>()
            {
                new Project()
                {
                    Content = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor 
                                incididunt ut labore et dolore magna aliqua.
                                Ut enim ad minim veniam, quis nostrud exercitation 
                                ullamco laboris nisi ut aliquip ex ea commodo consequat
                                . Duis aute irure dolor in reprehenderit in voluptate 
                                velit esse cillum dolore eu fugiat nulla pariatur
                                .Excepteur sint occaecat cupidatat non proident, 
                                sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Slug = "Blog, Business",
                    StartDate = new DateTime(2015, 11, 27),
                    EndDate = new DateTime(2016, 8, 27),
                    OwnerId = owner.OwnerId,
                    Url = @"https://www.youtube.com/watch?v=fmI_Ndrxy14",
                    ImgFrameUrl = "/Content/images/recent_projects1.png",
                    TimeSpan = null,
                    Title = "Amazing Project Title",
                    IsDeleted = 0
                }
            };
            foreach (var project in projects)
            {
                context.Projects.AddOrUpdate(project);
            }
            context.SaveChanges();
        }
    }
}
