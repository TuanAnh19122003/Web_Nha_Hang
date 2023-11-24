using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Nha_Hang.Models;

namespace Web_Nha_Hang.Areas.AdminArea.Controllers
{
    public class DefaultController : Controller
    {
        public static class Roles
        {
            public const string Admin = "Admin";
            public const string User = "User";
        }
        private DBConnectNhaHang db = new DBConnectNhaHang();
        // GET: AdminArea/Default
        [HttpGet]
        public ActionResult Login()
        {
            //Nếu đăng nhập rồi thì không cần đăng nhập lại vào thẳng trang
            if (Session["user"] != null)
            {
                /*return RedirectToAction("Index", "Dashbroad");*/
                return RedirectToAction("HomePage", "NhaHang", new { area = "" });
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = username;
            var pass = password;
            var acc = db.Nguoidungs.SingleOrDefault(x => x.taikhoan == user && x.matkhau == pass);
            System.Diagnostics.Debug.WriteLine($"Username: {user}, Password: {pass},ACC: { acc }");
            if (acc != null)
            { 
                Session["user"] = username;
                if (acc.maquyen==Roles.Admin)
                {
                    return RedirectToAction("Index", "Dashbroad");
                    
                }
                else
                {
                    return RedirectToAction("HomePage", "NhaHang", new { area = "" });
                }

            }
            else
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("HomePage", "NhaHang", new { area = "" });
        }
    }
}