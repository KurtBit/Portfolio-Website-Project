using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogCMS.Data;
using VGGLinkedIn.Models;

namespace BlogCMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext context = new BlogContext();

        public ActionResult Index()
        {
            var User = new User()
            {
                FullName = "Petromil Pavlov",
            };
            context.Users.Add(User);
            context.SaveChanges();
            var Post = new Post()
            {
                Content = "bla",
                CreatedAt = DateTime.Now,
                Slug = "bla",
                UserId = 1
                
            };
            context.Posts.Add(Post);
            context.SaveChanges();
            return View();
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
    }
}