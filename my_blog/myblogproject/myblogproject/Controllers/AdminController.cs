using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myblogproject.Models;
using System.Web.Helpers;
using System.IO;

namespace myblogproject.Controllers
{
    public class AdminController : Controller
    {
        myblogDB db = new myblogDB();
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.YorumSayisi = db.Yorum.Count();
            ViewBag.MakaleSayisi = db.Makale.Count();
            ViewBag.KullaniciSayisi = db.Kullanici.Count();
            ViewBag.BegeniSayisi = db.Makale.Sum(x => x.Begeni);


            return View();
        }
        // GET: AdminMakale/Details/5

        public ActionResult Makale()
        {
            var makaleler = db.Makale.ToList();

            return View(makaleler);
        }
        
        // GET: AdminMakale/Create
        public ActionResult MakaleEkle()
        {
            ViewBag.KategoriID = new SelectList(db.Kategori, "KategoriID", "KategoriAd");
            return View();
        }

        // POST: AdminMakale/Create
        [HttpPost]
        public ActionResult MakaleEkle(Makale makale, HttpPostedFileBase makaleResim, string AnahtarKelimeler)
        {


            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                if (makaleResim != null)
                {
                    WebImage img = new WebImage(makaleResim.InputStream);
                    FileInfo ResimBilgi = new FileInfo(makaleResim.FileName);

                    string YeniResim = Guid.NewGuid().ToString() + ResimBilgi.Extension;
                    img.Resize(700, 300);
                    img.Save("~/Resimler/MakaleResimleri/" + YeniResim);
                    makale.Makale_Resim = "/Resimler/MakaleResimleri/" + YeniResim;

                }
                if (AnahtarKelimeler != null)
                {
                    string[] anahtarkelimeler = AnahtarKelimeler.Split(',');
                    foreach (var i in anahtarkelimeler)
                    {
                        var eklenenetiket = new AnahtarKelime { AnahtarKelimeAd = i };
                        db.AnahtarKelime.Add(eklenenetiket);
                        makale.AnahtarKelime.Add(eklenenetiket);

                    }
                }
                makale.KullaniciID =Convert.ToInt32(Session["KullaniciID"]);
                db.Makale.Add(makale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {
                return View(makale);
            }
            
        }
        // GET: AdminMakale/Edit/5
        public ActionResult MakaleDuzenle(int id)
        {
            var makale = db.Makale.Where(x => x.MakaleID == id).SingleOrDefault();
            ViewBag.KategoriID = new SelectList(db.Kategori, "KategoriID", "KategoriAd", makale.KategoriID);
            return View(makale);

        }

        // POST: AdminMakale/Edit/5
        [HttpPost]
        public ActionResult MakaleDuzenle(int id, HttpPostedFileBase Resim, Makale makale)
        {
            if (ModelState.IsValid) { 
                // TODO: Add update logic here
                var makaleler = db.Makale.Where(x => x.MakaleID == id).SingleOrDefault();
                if (Resim != null)
                {
                    WebImage img = new WebImage(Resim.InputStream);
                    FileInfo ResimBilgi = new FileInfo(Resim.FileName);

                    string YeniResim = Guid.NewGuid().ToString() + ResimBilgi.Extension;
                    img.Resize(700, 300);
                    img.Save("~/Resimler/MakaleResimleri/" + YeniResim);
                    makaleler.Makale_Resim = "~/Resimler/MakaleResimleri/" + YeniResim;

                }

                makaleler.Baslik = makale.Baslik;
                makaleler.KategoriID = makale.KategoriID;
                makaleler.Makale_İcerik = makale.Makale_İcerik;

                db.SaveChanges();
                return RedirectToAction("Index");

            }

            else {
                return View(makale);
            }
        }

        // GET: AdminMakale/Delete/5
        public ActionResult MakaleSil(int id)
        {
            var makale = db.Makale.Where(x => x.MakaleID == id).SingleOrDefault();
            return View(makale);
        }

        // POST: AdminMakale/Delete/5
        [HttpPost]
        public ActionResult MakaleSil(int id,FormCollection collection)
        {
            if (ModelState.IsValid) {
                // TODO: Add delete logic here
                var makale = db.Makale.Where(x => x.MakaleID == id).SingleOrDefault();
                if (System.IO.File.Exists(Server.MapPath(makale.Makale_Resim)))
                {
                    System.IO.File.Delete(Server.MapPath(makale.Makale_Resim));
                }
                foreach (var i in makale.Yorum.ToList())
                {
                    db.Yorum.Remove(i);

                }
                foreach (var i in makale.AnahtarKelime.ToList())
                {
                    db.AnahtarKelime.Remove(i);
                }
                db.Makale.Remove(makale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}