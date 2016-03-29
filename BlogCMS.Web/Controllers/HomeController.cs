using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogCMS.Data;
using BlogCMS.Models;
using BlogCMS.Web.Models;
using Microsoft.AspNet.Identity;

namespace BlogCMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext context = new BlogContext();

        public ActionResult Index()
        {
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
            var user = context.Users.FirstOrDefault(x => x.IdentityId == User.Identity.GetUserId());

            ViewData["AvatarUrl"] = user.AvatarUrl;

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