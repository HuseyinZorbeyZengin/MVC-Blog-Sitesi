using BlogSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace BlogSitesi.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        // GET: Home
        public ActionResult Index(int sayfa = 1)
        {
            var makale = db.Makales.Where(m => m.Onay == true).Select(m => new MakaleModel()
            {
                ID = m.ID,
                Baslik = m.Baslik,
                KullaniciAdi = m.KullaniciAdi,
                Resim = m.Resim,
                YayinTarihi = m.YayinTarihi,
                Onay = m.Onay,
                GoruntulenmeSayisi = m.GoruntulenmeSayisi,
                Yorum = m.Yorum,
                Aciklama = m.Aciklama.Length > 60 ? m.Aciklama.Substring(0, 60) + ("[...]") : m.Aciklama


            }).ToList().ToPagedList(sayfa,3);
            return View(makale);
        }
        public ActionResult MakaleListesi(int? id)
        {
            var makale = db.Makales.Where(m => m.Onay == true).AsQueryable();
            if (id != null)
            {
                makale = makale.Where(m => m.KategoriID == id);
            }
            return View(makale.ToList());
        }
        public ActionResult Ara(string deger)
        {
            var ara = db.Makales.Where(m => m.Onay == true && m.Baslik.Contains(deger)).ToList();
            return View(ara);
        }
        public PartialViewResult EnCokOkunan()
        {
            var enCok = db.Makales.Where(m => m.Onay == true).OrderByDescending(m => m.GoruntulenmeSayisi).Take(5).ToList();
            return PartialView(enCok);
        }
        public ActionResult Detay(int id)
        {
            var makale = db.Makales.Find(id);
            ViewBag.makale = makale;

            var sayi = db.Makales.ToList().Find(x => x.ID == id);
            sayi.GoruntulenmeSayisi += 1;
            db.SaveChanges();

            var yorum = new Yorum()
            {
                MakaleID = makale.ID
            };

            return View("Detay", yorum);
        }
        public ActionResult YorumGonder(Yorum yorum, int? rating)
        {

            yorum.KullaniciID = User.Identity.Name;
            yorum.Tarih = DateTime.Now;
            yorum.Puan = Convert.ToInt32(rating);
            db.Yorums.Add(yorum);
            db.SaveChanges();
            return RedirectToAction("Detay", "Home", new { id = yorum.MakaleID });
        }
    }
}