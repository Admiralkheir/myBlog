using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using myblogproject.Models;

namespace myblogproject.Controllers
{
    public class AdminKullaniciController : Controller
    {
        private myblogDB db = new myblogDB();

        // GET: AdminKullanici
        public ActionResult Index()
        {
            var kullanici = db.Kullanici.Include(k => k.Yetki);
            return View(kullanici.ToList());
        }

        // GET: AdminKullanici/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = db.Kullanici.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // GET: AdminKullanici/Create
        public ActionResult Create()
        {
            ViewBag.YetkiID = new SelectList(db.Yetki, "YetkiID", "YetkiHali");
            return View();
        }

        // POST: AdminKullanici/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KullaniciID,YetkiID,AdSoyad,Eposta,Parola,GirisID")] Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                db.Kullanici.Add(kullanici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.YetkiID = new SelectList(db.Yetki, "YetkiID", "YetkiHali", kullanici.YetkiID);
            return View(kullanici);
        }

        // GET: AdminKullanici/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = db.Kullanici.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            ViewBag.YetkiID = new SelectList(db.Yetki, "YetkiID", "YetkiHali", kullanici.YetkiID);
            return View(kullanici);
        }

        // POST: AdminKullanici/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KullaniciID,YetkiID,AdSoyad,Eposta,Parola,GirisID")] Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kullanici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.YetkiID = new SelectList(db.Yetki, "YetkiID", "YetkiHali", kullanici.YetkiID);
            return View(kullanici);
        }

        // GET: AdminKullanici/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = db.Kullanici.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // POST: AdminKullanici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kullanici kullanici = db.Kullanici.Find(id);
            db.Kullanici.Remove(kullanici);
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
