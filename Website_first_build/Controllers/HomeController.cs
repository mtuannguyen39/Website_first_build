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

        public ActionResult Main(int? category, int? page, string SearchString, double min = double.MinValue, double max = double.MaxValue) 
        {
            // Tạo tin tức và có tham chiếu đến category
            var news = db.News.Include(p => p.Category);
            // Tìm kiếm chuỗi truy vấn theo category
            if(category == null)
            {
                news = db.News.OrderByDescending(x => x.NewsTitle);
            }
            else
            {
                news = db.News.OrderByDescending(x => x.CategoryID);
            }
            // Tìm kiếm theo tên
            if(!String.IsNullOrEmpty(SearchString))
            {
                news = news.Where(s => s.NewsTitle.ToLower().Contains(SearchString));
            }

            // Khai báo mỗi trang 5 sản phẩm
            int pageSize = 5;
            // Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page,
            //còn nếu page == null thì lấy giá trị 1 cho biến pageNumber
            int pageNumber = (page ?? 1);

            //Nếu page == null thì đặt lại page là 1 
            if (page == null) page = 1;

            var newsItems = db.News.ToList();
            return View(news.ToPagedList(pageNumber,pageSize));
        }
    }
}