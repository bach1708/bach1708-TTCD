﻿using System.Web;
using System.Web.Mvc;

namespace K22_CNT2_NongVanBach
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
