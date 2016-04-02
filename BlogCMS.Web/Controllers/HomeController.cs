using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using BlogCMS.Data;
using BlogCMS.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlogCMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext context = new BlogContext();

        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var avatarUrl = context.Users.Where(x => x.Role == "Owner").Select(x => x.AvatarUrl).FirstOrDefault();
            ViewBag.AvatarUrl = avatarUrl;

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

        public ActionResult Portfolio()
        {
            ViewBag.Message = "Your portfolio page.";

            return View();
        }
    }
}