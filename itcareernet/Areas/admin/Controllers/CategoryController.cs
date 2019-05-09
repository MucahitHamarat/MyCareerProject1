using Career.BLL.Repositories;
using Career.BOL.Entities;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace itcareernet.Areas.admin.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        Repository<Category> repoCategory = new Repository<Category>();

        // GET: admin/Category
        public ActionResult Index()
        {
            return View(repoCategory.GetAll());
        }

        // GET: admin/Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = repoCategory.GetBy(g => g.ID == id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: admin/Category/Create
        public ActionResult Create()
        {
            ViewBag.categories = repoCategory.GetAll().Where(w => w.ParentID == null);
            return View();
        }

        // POST: admin/Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                repoCategory.Add(category);
                return RedirectToAction("Index");
            }


            return View(category);
        }

        // GET: admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.categories = repoCategory.GetAll().Where(w => w.ParentID == null);
            Category category = repoCategory.GetBy(g => g.ID == id);
            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        // POST: admin/Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                repoCategory.Update(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: admin/Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = repoCategory.GetBy(g => g.ID == id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = repoCategory.GetBy(g => g.ID == id);
            repoCategory.Remove(category);
            return RedirectToAction("Index");
        }


    }
}
