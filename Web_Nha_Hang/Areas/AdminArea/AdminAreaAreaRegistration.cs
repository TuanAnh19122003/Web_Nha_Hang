using System.Web.Mvc;

namespace Web_Nha_Hang.Areas.AdminArea
{
    public class AdminAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminArea_default",
                "AdminArea/{controller}/{action}/{id}",
                new { Controller="Dashbroad",  action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}