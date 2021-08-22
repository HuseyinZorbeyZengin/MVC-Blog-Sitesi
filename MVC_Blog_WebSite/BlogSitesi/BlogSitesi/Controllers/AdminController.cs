using BlogSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesi.Controllers
{
    public class AdminController : Controller
    {
        DataContext db = new DataContext();
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.onaylanmis = db.Makales.Where(m => m.Onay == true).Count();
            ViewBag.onaylanmamis = db.Makales.Where(m => m.Onay == false).Count();
            ViewBag.sayi = db.Makales.Count();
            return View();
        }
        public ActionResult YazarListesi()
        {
            var makale = db.Makales.ToList();
            return View(makale);
        }
        public ActionResult OnayListesi()
        {
            var makale = db.Makales.Where(m => m.Onay == true).ToList();
            return View(makale);
        }
        public ActionResult OnaysızListesi()
        {
            var makale = db.Makales.Where(m => m.Onay == false).ToList();
            return View(makale);
        }
    }
}