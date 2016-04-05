using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BlogCMS.Data;
using BlogCMS.Models;
using BlogCMS.Web.Models;

namespace BlogCMS.Web.Controllers
{
    public class ProjectsController : Controller
    {
        private BlogContext context = new BlogContext();


        // GET: Projects
        public ActionResult Index()
        {
            var projects = context.Projects;
            if (projects != null)
            {
                IEnumerable<ProjectsViewModel> model = projects.Select(x => new ProjectsViewModel()
                {
                    Content = x.Content,
                    OwnerId = x.OwnerId,
                    Title = x.Title,
                    Slug = x.Slug,
                    TimeSpan = x.TimeSpan,
                    Url = x.Url,
                    ImgFrameUrl = x.ImgFrameUrl
                });

                return this.View(model);
            }

            return this.View();
        }
    }
}