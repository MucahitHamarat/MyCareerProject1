using Career.BLL.Repositories;
using Career.BOL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace itcareernet.Controllers
{
    public class AJAXController : Controller
    {
        Repository<FindJobSubCategory> repoFindJobSubCategory = new Repository<FindJobSubCategory>();
        Repository<EmployeeDDownSubList> repoEmployeeDDownSubList = new Repository<EmployeeDDownSubList>();
        
        // GET: AJAX
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SubCategories(int id)
        {
            return Json(repoFindJobSubCategory.GetAll().Where(w => w.FindJobCategoryID == id), JsonRequestBehavior.AllowGet);

        }
        public ActionResult SubCategories2(int id2)
        {
            List<EmployeeDDownSubList> y = repoEmployeeDDownSubList.GetAll().Where(w => w.FindEmployeeCatsID == id2).ToList
                ();
            return Json(y, JsonRequestBehavior.AllowGet);

        }
    }
}