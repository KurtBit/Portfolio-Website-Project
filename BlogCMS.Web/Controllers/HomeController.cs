using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BlogCMS.Data;
using BlogCMS.Web.Models;
using Microsoft.AspNet.Identity;

namespace BlogCMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext context = new BlogContext();

        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var avatarUrl = context.Users.Where(x => x.Role == "Owner").Select(x => x.AvatarUrl).FirstOrDefault();
            var aboutMe = context.Users.Where(x => x.Role == "Owner").Select(x => x.AboutMe).FirstOrDefault();
            ViewBag.AvatarUrl = avatarUrl;
            ViewBag.AboutMe = aboutMe;

            var posts = context.Posts;
            if (posts != null)
            {
                IEnumerable<PostViewModel> model = posts.Select(x => new PostViewModel()
                {
                    Content = x.Content,
                    CreatedAt = x.CreatedAt,
                    Title = x.Title,
                    isDeleted = x.IsDeleted
                });

                return this.View(model);
            }
                return this.View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Skills()
        {
            ViewBag.Message = "Your portfolio page.";

            return View();
        }
    }
}