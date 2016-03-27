using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BlogCMS.Data;
using BlogCMS.Models;
using BlogCMS.Web.Areas.Admin.InputModel;
using BlogCMS.Web.Areas.Admin.Models;
using Microsoft.AspNet.Identity;


namespace BlogCMS.Web.Areas.Admin.Controllers
{
    //[Authorize(Roles = "admin")]
    public class PostsController : Controller
    {
        private BlogContext context = new BlogContext();

        // GET: Admin/Posts
        public ActionResult Index()
        {
            var posts = context.Posts;

            IEnumerable<PostsIndexViewModel> model = posts.Select(x => new PostsIndexViewModel()
            {
                Author = x.User.Email,
                Id = x.Id,
                PostedAt = x.CreatedAt,
                Tag = x.Slug,
                Title = x.Title,
                IsDeleted = x.IsDeleted
            });

            return View(model);
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
                UserId = User.Identity.GetUserId()
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