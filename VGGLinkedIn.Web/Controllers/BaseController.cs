using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using VGGLinkedIn.Data;
using VGGLinkedIn.Models;

namespace VGGLinkedIn.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        private IVggLinkedInData _data;
        private User userProfile;

        protected BaseController(IVggLinkedInData data)
        {
            this._data = data;
        }

        protected BaseController(IVggLinkedInData data, User userProfile)
            : this(data)
        {
            this.UserProfile = userProfile;
        }

        protected IVggLinkedInData Data { get; private set; }

        protected User UserProfile { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                //var username = requestContext.HttpContext.User.Identity.Name;
                //var user = this.Data.Users.All().FirstOrDefault(x => x.UserName == username);
                //this.UserProfile = user;
            }
            
            return base.BeginExecute(requestContext, callback, state);
        }
    }
}