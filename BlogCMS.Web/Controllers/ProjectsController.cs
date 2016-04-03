using System.Web.Mvc;

namespace BlogCMS.Web.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: Projects
        public ActionResult Index()
        {
            return View();
        }
    }
}