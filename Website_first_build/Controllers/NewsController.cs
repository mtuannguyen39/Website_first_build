using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Website_first_build.Models;

namespace Website_first_build.Controllers
{
    public class NewsController : Controller
    {
        private DBNhaThoEntities db = new DBNhaThoEntities();

        // GET: News
        public ActionResult Index()
        {
            var news = db.News.Include(n => n.Category).Include(n => n.MinistryYear);
            return View(news.ToList());
        }

        // GET: News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New @new = db.News.Find(id);
            if (@new == null)
            {
                return HttpNotFound();
            }
            return View(@new);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            ViewBag.MinistryYearID = new SelectList(db.MinistryYears, "YearID", "YearName");
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(New @new, HttpPostedFileBase uploadHinh)
        {
                if(uploadHinh != null && uploadHinh.ContentLength > 0)
                {
                    int id = int.Parse(db.News.ToList().Last().ID.ToString());

                    string _FileName = "";
                    int index = uploadHinh.FileName.IndexOf('.');
                    _FileName = "news" + id.ToString() + "." + uploadHinh.FileName.Substring(index + 1);
                    string _path = Path.Combine(Server.MapPath("~/Images/Upload"), _FileName);
                    uploadHinh.SaveAs(_path);

                    New unv = db.News.FirstOrDefault(x => x.ID == id);
                    unv.MainImage = _FileName;
                    db.SaveChanges();
                }
                db.News.Add(@new);
                db.SaveChanges();
                return RedirectToAction("Index");

            //ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", @new.CategoryID);
            //ViewBag.MinistryYearID = new SelectList(db.MinistryYears, "YearID", "YearName", @new.MinistryYearID);
            //return View(@new);
        }

        // GET: News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New @new = db.News.Find(id);
            if (@new == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", @new.CategoryID);
            ViewBag.MinistryYearID = new SelectList(db.MinistryYears, "YearID", "YearName", @new.MinistryYearID);
            return View(@new);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(New @new, HttpPostedFileBase uploadHinh)
        {
            if (ModelState.IsValid)
            {
                New news = db.News.FirstOrDefault(x => x.ID == @new.ID);
                news.NewsTitle = @new.NewsTitle;
                news.NewsDesc = @new.NewsDesc;
                news.MinistryYearID = @new.MinistryYearID;
                news.CategoryID = @new.CategoryID;
                news.MainImage = @new.MainImage;
                if(uploadHinh != null && uploadHinh.ContentLength > 0)
                {
                    int id = @new.ID;
                    string _FileName = "";
                    int index = uploadHinh.FileName.IndexOf('.');
                    _FileName = id.ToString() + "." + uploadHinh.FileName.Substring(index + 1);
                    string _path = Path.Combine(Server.MapPath("~/Images/Upload"), _FileName);
                    uploadHinh.SaveAs(_path);
                    news.MainImage = _FileName;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", @new.CategoryID);
            ViewBag.MinistryYearID = new SelectList(db.MinistryYears, "YearID", "YearName", @new.MinistryYearID);
            return View(@new);
        }

        // GET: News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New @new = db.News.Find(id);
            if (@new == null)
            {
                return HttpNotFound();
            }
            return View(@new);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            New @new = db.News.Find(id);
            db.News.Remove(@new);
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
