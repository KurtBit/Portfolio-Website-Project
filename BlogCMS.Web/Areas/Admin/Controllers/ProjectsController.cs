using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using BlogCMS.Data;
using BlogCMS.Models;
using BlogCMS.Web.Areas.Admin.InputModel;
using BlogCMS.Web.Areas.Admin.Models;

namespace BlogCMS.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private BlogContext context = new BlogContext();

        // GET: Admin/Projects
        [HttpGet]
        public ActionResult Index()
        {
            
            var projects = context.Projects;
            var owners = context.Owner;

            IEnumerable<ProjectsViewModel> model = projects.Select(x => new ProjectsViewModel()
            {
                Author = x.Owner.User.FullName,
                Content = x.Content,
                TimeSpan = x.TimeSpan,
                Title = x.Title,
                Slug = x.Slug,
                Url = x.Url,
                ImgFrameUrl = x.ImgFrameUrl,
                IsDeleted = x.IsDeleted,
                Id = x.ProjectId
            });
  
            return View(model);
        }

        [HttpGet]
        public ActionResult New()
        {
            var model = new ProjectInputModel();

            return View(model);
        }

        [HttpPost,ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult New(ProjectInputModel model)
        {
            var ownerId = context.Owner.Select(x => x.OwnerId).FirstOrDefault();
            var timeSpan = model.EndDate.Subtract(model.StartDate);

            if (ModelState.IsValid)
            {
                var project = new Project()
                {
                    Title = model.Title,
                    ImgFrameUrl = model.ImgFrameUrl,
                    Content = model.Content,
                    OwnerId = ownerId,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    TimeSpan = timeSpan,
                    Slug = model.Slug,
                    Url = model.Url,
                    IsDeleted = 0
                };

                context.Projects.Add(project);
                context.SaveChanges();

                return Content("Success");
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var project = context.Projects.FirstOrDefault(x => x.ProjectId == id);

            project.IsDeleted = 1;
            project.DeletedAt = DateTime.Now;
            context.Projects.AddOrUpdate(project);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Restore(int id)
        {
            var project = context.Projects.FirstOrDefault(x => x.ProjectId == id);

            project.IsDeleted = 0;
            project.DeletedAt = DateTime.Now;
            context.Projects.AddOrUpdate(project);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}