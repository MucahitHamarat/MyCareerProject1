using Career.BLL.Repositories;
using Career.BOL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace itcareernet.Controllers
{
    public class GetJobController : Controller
    {
        
        Repository<FindEmployeeSubCats> repoFindEmployeeSubCats = new Repository<FindEmployeeSubCats>();
      
        public ActionResult Index()
        {

           
            ViewData["JobCount"] = repoFindEmployeeSubCats.GetAll().Count();
            ViewBag.getJob = repoFindEmployeeSubCats.GetAll();
             return View();
        }
    }
}