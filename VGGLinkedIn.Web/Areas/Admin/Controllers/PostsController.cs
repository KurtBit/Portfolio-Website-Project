using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
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
        IVggLinkedInContext context = new VggLinkedInContext();

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

        [HttpPost, ValidateAntiForgeryToken, ValidateInput(false)]
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
                Title = model.Title,
                Slug = model.Slug,
                UserId = User.Identity.GetUserId()
            };

            context.Post.Add(post);
            context.SaveChanges();
            //Data.Posts.Add(post);
            //Data.SaveChanges();

            return Content("Added Post Successfully");
        }

        public ActionResult Edit()
        {
            return View();
        }
    }
}