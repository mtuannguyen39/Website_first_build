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
    public class AdminsController : Controller
    {
        private DBNhaThoEntities1 db = new DBNhaThoEntities1();

        // GET: Admins
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAccount(Admin _user)
        {
            var check = db.Admins.Where(s => s.Email == _user.Email && s.PasswordUser == _user.PasswordUser).FirstOrDefault();
            if(check == null)
            {
                ViewBag.ErrorInfo = "Sai Info";
                return View("Index");
            } else
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                Session["ID"] = _user.ID;
                Session["NameUser"] = _user.NameUser;
                Session["PasswordUser"] = _user.PasswordUser;
                Session["RoleUser"] = _user.RoleUser;
                Session["Email"] = _user.Email;
                if (check.RoleUser.ToString() == "Admin")
                    return RedirectToAction("ADIndex", "News");
                else if (check.RoleUser.ToString() == "DangTin")
                    return RedirectToAction("Index", "News");
                else if (check.RoleUser.ToString() == "QuanLy")
                    return RedirectToAction("Index", "Users");
                else return RedirectToAction("Index", "LoginUser");
            }
        }

        public ActionResult LogOutUserAd()
        {
            Session.Remove("NameUser");
            return RedirectToAction("Index", "AdminUsers");
        }

        [HttpGet]
        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(Admin _user)
        {
            if(ModelState.IsValid)
            {
                var check_ID = db.Admins.Where(s => s.ID == _user.ID).FirstOrDefault();
                if(check_ID == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Admins.Add(_user);
                    db.SaveChanges();
                    return RedirectToAction("Index", "AdminUsers");
                }
                else
                {
                    ViewBag.ErrorRegister = "This ID is exist";
                    return View();
                }
            }
            return View();
        }
        public ActionResult ViewAd()
        {
            return View();
        }
    }
}
