using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Nha_Hang.Models;
using System.Data.Entity;

namespace Web_Nha_Hang.App_Start
{
    public class SessionConfig
    {
        public static void SaveUser(Nguoidung user)
        {
            HttpContext.Current.Session["user"] = user;
            HttpContext.Current.Session["role"] = user.Quyen.tenquyen;
        }

        // Lấy user từ Session
        public static Nguoidung GetUser()
        {
            if (HttpContext.Current.Session["user"] != null)
            {
                return (Nguoidung)HttpContext.Current.Session["user"];
            }
            return null;
        }

        // Lấy quyền từ Session
        public static string GetRole()
        {
            return HttpContext.Current.Session["role"] as string;
        }

        // Xóa user và quyền khỏi Session khi cần
        public static void ClearUser()
        {
            HttpContext.Current.Session.Remove("user");
            HttpContext.Current.Session.Remove("role");
        }
    }
}