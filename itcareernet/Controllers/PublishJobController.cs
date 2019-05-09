using Career.BLL.Repositories;
using Career.BOL.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace itcareernet.Controllers
{
    public class PublishJobController : Controller
    {
        Repository<FindEmployeeSubCats> repoFESC = new Repository<FindEmployeeSubCats>();
        Repository<City> repoCities = new Repository<City>();
        // GET: PublishJob
        public ActionResult Index()
        {
            List<FindEmployeeSubCats> Models = new List<FindEmployeeSubCats>();
            Models = repoFESC.GetAll().ToList();
            //ViewData["cities"] = repoCities.GetAll().ToList();
            //ViewBag.Cities = repoCities.GetAll().ToList();
            return View(Models);
        }

        // GET: PublishJob/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FindEmployeeSubCats findEmployeeSubCats = repoFESC.GetBy(g=>g.ID==id);
            if (findEmployeeSubCats == null)
            {
                return HttpNotFound();
            }
            return View(findEmployeeSubCats);
        }

        // GET: PublishJob/Create
        public ActionResult Create()
        {
            //List<City> cities = new List<City>();
            ViewBag.Cities = repoCities.GetAll().ToList();
            return View();
        }

       
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Create(FindEmployeeSubCats findEmployeeSubCats,HttpPostedFileBase Logo/*,int Plaque*/)
        {
            if (ModelState.IsValid)
            {

                if (Logo != null)
                {
                    if (!Directory.Exists(Server.MapPath("~/Content/img/logos")))
                        Directory.CreateDirectory(Server.MapPath("~/Content/img/logos"));
                    else Logo.SaveAs(Server.MapPath("~/Content/img/logos" + Logo.FileName));
                }

                repoFESC.Add(findEmployeeSubCats);  
                
                return RedirectToAction("Index");
            }

            return View(findEmployeeSubCats);
        }

        // GET: PublishJob/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FindEmployeeSubCats findEmployeeSubCats = repoFESC.GetBy(i=>i.ID==id);
            if (findEmployeeSubCats == null)
            {
                return HttpNotFound();
            }
            return View(findEmployeeSubCats);
        }

        // POST: PublishJob/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CompanyName,JobTitle,Email,Description,Logo,MilitaryState,Experience,JobType,PosLevel")] FindEmployeeSubCats findEmployeeSubCats)
        {
            if (ModelState.IsValid)
            {
                repoFESC.Update(findEmployeeSubCats);
                
                return RedirectToAction("Index");
            }
            return View(findEmployeeSubCats);
        }

        // GET: PublishJob/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FindEmployeeSubCats findEmployeeSubCats = repoFESC.GetBy(i => i.ID == id);
            if (findEmployeeSubCats == null)
            {
                return HttpNotFound();
            }
            return View(findEmployeeSubCats);
        }

        // POST: PublishJob/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FindEmployeeSubCats findEmployeeSubCats = repoFESC.GetBy(i => i.ID == id);
            repoFESC.Remove(findEmployeeSubCats);
            
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        repoFESC.GetBy(i=>i.ID==id).Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
