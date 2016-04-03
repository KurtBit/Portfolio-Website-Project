using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using BlogCMS.Data;
using BlogCMS.Web.Areas.Admin.InputModel;
using Microsoft.AspNet.Identity;

namespace BlogCMS.Web.Areas.Admin.Controllers
{
    public class ProfileController : Controller
    {
        private BlogContext context = new BlogContext();

        // GET: Admin/Profile
        [HttpGet]
        public ActionResult Index()
        {
            var user = context.Users.Where(x => x.Role == "Owner").Select(x => x).FirstOrDefault();

            var model = new ProfileInputModel()
            {
                AvatarUrl = user.AvatarUrl,
                AboutMe = user.AboutMe
            };

            return View(model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Index(ProfileInputModel model)
        {
            var userId = User.Identity.GetUserId();
            var user = context.Users.FirstOrDefault(x => x.Id == userId);// needs to authenticate

            if (user != null)
            {
                user.AvatarUrl = model.AvatarUrl;
                user.AboutMe = model.AboutMe;
                context.Users.AddOrUpdate(user);
                context.SaveChanges();
                return Content("Success");
            }

            return View();
        }
    }
}