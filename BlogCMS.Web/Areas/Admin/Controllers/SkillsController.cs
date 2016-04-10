using System.Linq;
using System.Web.Mvc;
using BlogCMS.Data;
using BlogCMS.Models;
using BlogCMS.Web.Areas.Admin.InputModel;

namespace BlogCMS.Web.Areas.Admin.Controllers
{
    public class SkillsController : Controller
    {
        private BlogContext context = new BlogContext();

        [HttpGet]
        public ActionResult Index()
        {
            var model = new SkillInputModel();

            return View();
        }

        [HttpPost]
        public ActionResult Index(SkillInputModel model)
        {
            var owner = context.Owner.FirstOrDefault();

            if (ModelState.IsValid)
            {
                var skill = new Skill()
                {
                    AvatarUrl = model.AvatarUrl,
                    KnowledgeLevel = model.KnowledgeLevel,
                    SkillName = model.SkillName,
                    StartedAt = model.StartedAt,
                    Type = model.Type,
                    OwnedId = owner.OwnerId
                };
                return Content("Success");
            }

            return View();
        }
    }
}
