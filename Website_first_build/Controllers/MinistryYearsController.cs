using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Website_first_build.Models;

namespace Website_first_build.Controllers
{
    public class MinistryYearsController : Controller
    {
        private DBNhaThoEntities db = new DBNhaThoEntities();

        // GET: MinistryYears
        public ActionResult Index()
        {
            var ministryYears = db.MinistryYears.Include(m => m.Category);
            return View(ministryYears.ToList());
        }

        // GET: MinistryYears/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinistryYear ministryYear = db.MinistryYears.Find(id);
            if (ministryYear == null)
            {
                return HttpNotFound();
            }
            return View(ministryYear);
        }

        // GET: MinistryYears/Create
        public ActionResult Create()
        {
            ViewBag.IDCateYear = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: MinistryYears/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YearID,YearName,YearDes,IDCateYear")] MinistryYear ministryYear)
        {
            if (ModelState.IsValid)
            {
                db.MinistryYears.Add(ministryYear);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCateYear = new SelectList(db.Categories, "ID", "Name", ministryYear.IDCateYear);
            return View(ministryYear);
        }

        // GET: MinistryYears/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinistryYear ministryYear = db.MinistryYears.Find(id);
            if (ministryYear == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCateYear = new SelectList(db.Categories, "ID", "Name", ministryYear.IDCateYear);
            return View(ministryYear);
        }

        // POST: MinistryYears/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YearID,YearName,YearDes,IDCateYear")] MinistryYear ministryYear)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ministryYear).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCateYear = new SelectList(db.Categories, "ID", "Name", ministryYear.IDCateYear);
            return View(ministryYear);
        }

        // GET: MinistryYears/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinistryYear ministryYear = db.MinistryYears.Find(id);
            if (ministryYear == null)
            {
                return HttpNotFound();
            }
            return View(ministryYear);
        }

        // POST: MinistryYears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MinistryYear ministryYear = db.MinistryYears.Find(id);
            db.MinistryYears.Remove(ministryYear);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
