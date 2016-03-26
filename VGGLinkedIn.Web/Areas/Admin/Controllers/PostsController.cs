using System;
using System.Web.Mvc;
using VGGLinkedIn.Data;
using VGGLinkedIn.Models;
using VGGLinkedIn.Web.Controllers;
using VGGLinkedIn.Web.InputModels;

namespace VGGLinkedIn.Web.Areas.Admin.Controllers
{
    public class PostsController : BaseController
    { 
        public PostsController(IVggLinkedInData data) 
            : base(data)
        {
        }
    
        // GET: Admin/Posts
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new AddPostInputModel();

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Add(AddPostInputModel model )
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var post = new Post()
            {
                Content = model.Content,
                CreatedAt = DateTime.Now,
                Title = model.Title
            };
            Data.Posts.Add(post);
            Data.SaveChanges();

            return Content("Added Post Successfully");
        }

        public ActionResult Edit()
        {
            return View();
        }
    }
}