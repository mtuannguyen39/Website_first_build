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
    public class VersesController : Controller
    {
        private DBNhaThoEntities db = new DBNhaThoEntities();

        // GET: Verses
        public ActionResult Index()
        {
            var verses = db.Verses.Include(v => v.Chapter);
            return View(verses.ToList());
        }

        // GET: Verses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verse verse = db.Verses.Find(id);
            if (verse == null)
            {
                return HttpNotFound();
            }
            return View(verse);
        }

        // GET: Verses/Create
        public ActionResult Create()
        {
            ViewBag.ChapterID = new SelectList(db.Chapters, "ID", "ID");
            return View();
        }

        // POST: Verses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ChapterID,VerseNumber,VerseText")] Verse verse)
        {
            if (ModelState.IsValid)
            {
                db.Verses.Add(verse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChapterID = new SelectList(db.Chapters, "ID", "ID", verse.ChapterID);
            return View(verse);
        }

        // GET: Verses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verse verse = db.Verses.Find(id);
            if (verse == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChapterID = new SelectList(db.Chapters, "ID", "ID", verse.ChapterID);
            return View(verse);
        }

        // POST: Verses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ChapterID,VerseNumber,VerseText")] Verse verse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(verse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChapterID = new SelectList(db.Chapters, "ID", "ID", verse.ChapterID);
            return View(verse);
        }

        // GET: Verses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verse verse = db.Verses.Find(id);
            if (verse == null)
            {
                return HttpNotFound();
            }
            return View(verse);
        }

        // POST: Verses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Verse verse = db.Verses.Find(id);
            db.Verses.Remove(verse);
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
