using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace itcareernet.Areas.admin.Controllers
{
    [Authorize(Roles="admin")]
    public class HomeAdminController : Controller
    {
        // GET: admin/HomeAdmin
        public ActionResult Index()
        {
            return View();
        }
    }
}