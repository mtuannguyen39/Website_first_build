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
    public class BibleVersionsController : Controller
    {
        private DBNhaThoEntities db = new DBNhaThoEntities();

        // GET: BibleVersions
        public ActionResult Index()
        {
            return View(db.BibleVersions.ToList());
        }

        // GET: BibleVersions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BibleVersion bibleVersion = db.BibleVersions.Find(id);
            if (bibleVersion == null)
            {
                return HttpNotFound();
            }
            return View(bibleVersion);
        }

        // GET: BibleVersions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BibleVersions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] BibleVersion bibleVersion)
        {
            if (ModelState.IsValid)
            {
                db.BibleVersions.Add(bibleVersion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bibleVersion);
        }

        // GET: BibleVersions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BibleVersion bibleVersion = db.BibleVersions.Find(id);
            if (bibleVersion == null)
            {
                return HttpNotFound();
            }
            return View(bibleVersion);
        }

        // POST: BibleVersions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] BibleVersion bibleVersion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bibleVersion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bibleVersion);
        }

        // GET: BibleVersions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BibleVersion bibleVersion = db.BibleVersions.Find(id);
            if (bibleVersion == null)
            {
                return HttpNotFound();
            }
            return View(bibleVersion);
        }

        // POST: BibleVersions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BibleVersion bibleVersion = db.BibleVersions.Find(id);
            db.BibleVersions.Remove(bibleVersion);
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
