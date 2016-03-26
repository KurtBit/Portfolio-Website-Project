using System;
using System.Web.Mvc;
using BlogCMS.Data;
using BlogCMS.Models;
using BlogCMS.Web.Areas.Admin.InputModel;


namespace BlogCMS.Web.Areas.Admin.Controllers
{
    public class PostsController : Controller
    {
        private BlogContext context = new BlogContext();

        // GET: Admin/Posts
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            var model = new NewPostInputModel();

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult New(NewPostInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var post = new Post()
            {
                Content = model.Content,
                CreatedAt = DateTime.Now,
                Title = model.Title,
                Slug = model.Slug,
                UserId = 2 // not good
            };

            context.Posts.Add(post);
            context.SaveChanges();
           
            return Content("Added Post Successfully");
        }

        public ActionResult Edit()
        {
            return View();
        }
    }
}