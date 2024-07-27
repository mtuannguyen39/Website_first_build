using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using Website_first_build.Models;
using PagedList;

namespace Website_first_build.Controllers
{
    public class HomeController : Controller
    {
        private DBNhaThoEntities db = new DBNhaThoEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Main()
        {
            var newsItems = db.News.ToList();
            return View(newsItems);
        }
    }
}