using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using BlogCMS.Data;
using BlogCMS.Models;
using BlogCMS.Web.Areas.Admin.InputModel;
using BlogCMS.Web.Areas.Admin.Models;
using Microsoft.AspNet.Identity;


namespace BlogCMS.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private BlogContext context = new BlogContext();

        // GET: Admin/Posts
        [HttpGet]
        public ActionResult Index()
        {
            var posts = context.Posts;

            IEnumerable<PostsIndexViewModel> model = posts.Select(x => new PostsIndexViewModel()
            {
                Author = x.User.Email,
                Id = x.PostId,
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
                UserId = User.Identity.GetUserId(),
                IsDeleted = 0
            };

            context.Posts.Add(post);
            context.SaveChanges();
           
            return Content("Added Post Successfully");
        }

        public ActionResult Delete(int id)
        {
            var post = context.Posts.FirstOrDefault(x => x.PostId == id);

            post.IsDeleted = 1;
            post.DeletedAt = DateTime.Now;
            context.Posts.AddOrUpdate(post);
            context.SaveChanges();
            
            return RedirectToAction("Index");
        }

        public ActionResult Restore(int id)
        {
            var post = context.Posts.FirstOrDefault(x => x.PostId == id);

            post.IsDeleted = 0;
            post.DeletedAt = DateTime.Now;
            context.Posts.AddOrUpdate(post);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}