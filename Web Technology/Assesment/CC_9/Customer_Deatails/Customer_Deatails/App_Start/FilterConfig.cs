﻿using System.Web;
using System.Web.Mvc;

namespace Customer_Deatails
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
