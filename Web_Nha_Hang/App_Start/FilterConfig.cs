﻿using System.Web;
using System.Web.Mvc;

namespace Web_Nha_Hang
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
