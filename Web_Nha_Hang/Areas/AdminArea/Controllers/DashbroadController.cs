using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Web_Nha_Hang.Areas.AdminArea.Controllers.DefaultController;

namespace Web_Nha_Hang.Areas.AdminArea.Controllers
{

    public class DashbroadController : Controller
    {
        // GET: AdminArea/Dashbroad
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var role = Session["userRole"] as string;

            if (role != null && role == Roles.Admin)
            {
                // The code for the Admin Dashboard page
                return View();
            }
            else
            {
                // Redirect to a page indicating unauthorized access
                return RedirectToAction("Login", "Default", new { area = "AdminArea" });
            }
        }
    }
}