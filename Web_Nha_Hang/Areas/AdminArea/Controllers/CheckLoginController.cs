using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Nha_Hang.Areas.AdminArea.Controllers
{
    public class CheckLoginController : Controller
    {
        // GET: AdminArea/CheckLogin
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["user"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(new {Controller="Default" ,Action="Login"})
                );
            }
            base.OnActionExecuting(filterContext);
        }
    }
}