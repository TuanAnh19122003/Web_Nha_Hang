using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Web_Nha_Hang.Areas.AdminArea.Controllers.DefaultController;

namespace Web_Nha_Hang.Areas.AdminArea.Controllers
{

    public class DashbroadController : CheckLoginController
    {
        // GET: AdminArea/Dashbroad
        
        public ActionResult Index()
        {
            return View();
        }
    }
}