﻿using System.Web.Mvc;

namespace itcareernet.Areas.admin
{
    public class adminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "admin_default",
                "admin/{controller}/{action}/{id}",

                new { controller="HomeAdmin",action = "Index", id = UrlParameter.Optional },
                new[] { "itcareernet.Areas.admin.Controllers" }
            );
        }
    }
}