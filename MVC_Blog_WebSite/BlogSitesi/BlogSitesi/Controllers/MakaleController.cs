using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogSitesi.Models;

namespace BlogSitesi.Controllers
{
    public class MakaleController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Makale
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var makale = db.Makales.Where(i => i.KullaniciAdi == username).Select(m => new MakaleModel()
            {
                ID = m.ID,
                Baslik = m.Baslik,
                KullaniciAdi = m.KullaniciAdi,
                Resim = m.Resim,
                YayinTarihi = m.YayinTarihi,
                Onay = m.Onay,
                GoruntulenmeSayisi = m.GoruntulenmeSayisi,
                Yorum = m.Yorum,
                Aciklama = m.Aciklama.Length > 30 ? m.Aciklama.Substring(0, 30) + ("[...]") : m.Aciklama


            }).ToList();
            return View(makale);
        }

        // GET: Makale/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makale makale = db.Makales.Find(id);
            if (makale == null)
            {
                return HttpNotFound();
            }
            return View(makale);
        }

        // GET: Makale/Create
        public ActionResult Create()
        {
            ViewBag.KategoriID = new SelectList(db.Kategoris, "ID", "KategoriAdi");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Makale makale, HttpPostedFileBase File)
        {
            if (ModelState.IsValid)
            {
                makale.KullaniciAdi = User.Identity.Name;
                string yol = Path.Combine("/Content/img/" + File.FileName);
                File.SaveAs(Server.MapPath(yol));
                makale.Resim = File.FileName.ToString();
                db.Makales.Add(makale);
                db.SaveChanges();
                if (this.User.Identity.Name == "admin")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Onay");
                }

            }

            ViewBag.KategoriID = new SelectList(db.Kategoris, "ID", "KategoriAdi", makale.KategoriID);
            return View(makale);
        }

        // GET: Makale/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makale makale = db.Makales.Find(id);
            if (makale == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriID = new SelectList(db.Kategoris, "ID", "KategoriAdi", makale.KategoriID);
            return View(makale);
        }

        // POST: Makale/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,KullaniciAdi,Baslik,Aciklama,Resim,GoruntulenmeSayisi,YayinTarihi,Onay,KategoriID")] Makale makale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(makale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriID = new SelectList(db.Kategoris, "ID", "KategoriAdi", makale.KategoriID);
            return View(makale);
        }

        // GET: Makale/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makale makale = db.Makales.Find(id);
            if (makale == null)
            {
                return HttpNotFound();
            }
            return View(makale);
        }

        // POST: Makale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Makale makale = db.Makales.Find(id);
            db.Makales.Remove(makale);
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
