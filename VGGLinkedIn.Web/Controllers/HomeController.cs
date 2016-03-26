using System.Linq;
using System.Web.Mvc;
using VGGLinkedIn.Data;

namespace VGGLinkedIn.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IVggLinkedInData data) 
            : base(data)
        {
        }

        private const int PostsPerPage = 3;

        public ActionResult Index()
        {
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