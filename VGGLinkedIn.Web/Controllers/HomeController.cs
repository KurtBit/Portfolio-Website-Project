using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Glimpse.Core.Extensions;
using Microsoft.Ajax.Utilities;
using VGGLinkedIn.Data;
using VGGLinkedIn.Web.Models;

namespace VGGLinkedIn.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IVggLinkedInData data) 
            : base(data)
        {
        }

        IVggLinkedInContext context = new VggLinkedInContext();
        private const int PostsPerPage = 3;

        public ActionResult Index()
        {
            var posts = context.Post;
            if (posts != null)
            {
                IEnumerable<PostViewModel> model = posts.Select(x => new PostViewModel()
                {
                    Content = x.Content,
                    CreatedAt = x.CreatedAt,
                    Title = x.Title
                });

                return this.View(model);
            }

            return this.View();
        }

        public ActionResult About()
        {
            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";
            return this.View();
        }

    }
}