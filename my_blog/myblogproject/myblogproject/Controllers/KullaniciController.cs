using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myblogproject.Models;

namespace myblogproject.Controllers
{
    public class KullaniciController : Controller
    {
        myblogDB db = new myblogDB();
        // GET: Kullanici
        public ActionResult Index(int id)
        {
            var kullanici = db.Kullanici.Where(x => x.KullaniciID == id).SingleOrDefault();
            if (Convert.ToInt32(Session["KullaniciID"]) != kullanici.KullaniciID)
            {
                return HttpNotFound();
            }

            return View(kullanici);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(Kullanici kullanici)
        {
            
            var login = db.Kullanici.Where(x => x.GirisID == kullanici.GirisID).SingleOrDefault();
            
            while(15!=kullanici.Parola.Length)
            {
                kullanici.Parola = kullanici.Parola + " ";
            }
            while(15!=kullanici.GirisID.Length)
            {
                kullanici.GirisID = kullanici.GirisID + " ";
            }
            if (login.Parola == kullanici.Parola && login.GirisID == kullanici.GirisID)
            {
                Session["KullaniciID"] = login.KullaniciID;
                Session["GirisID"] = login.GirisID;
                Session["YetkiID"] = login.YetkiID;
                return RedirectToAction("Index", "Home"); //kullanici sayfasınada döndürebiliriz


            }

            else
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session["KullaniciID"] = null;
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult KullaniciOlustur()
        {
            return View();



        }
        [HttpPost]
        public ActionResult KullaniciOlustur(Kullanici kullanici)
        {

            if (ModelState.IsValid)
            {
                kullanici.YetkiID = 2;
                db.Kullanici.Add(kullanici);
                db.SaveChanges();
                Session["KullaniciID"] = kullanici.KullaniciID;
                Session["GirisID"] = kullanici.GirisID;
                return RedirectToAction("Index", "Home"); //kullanici sayfasına döndürebiliriz.


            }


            else
            {
                return View(kullanici);
            }


        }
        public ActionResult Duzenle(int id)
        {
            var kullanici = db.Kullanici.Where(x => x.KullaniciID == id).SingleOrDefault();


            return View(kullanici);
        }

        [HttpPost]

        public ActionResult Duzenle(Kullanici kullanici,int id)
        {

            if (ModelState.IsValid)
            {
                var kullanicilar= db.Kullanici.Where(x => x.KullaniciID == id).SingleOrDefault();
                kullanicilar.AdSoyad = kullanici.AdSoyad;
                kullanicilar.Eposta = kullanici.Eposta;
                kullanicilar.Parola = kullanici.Parola;
                kullanicilar.GirisID = kullanici.GirisID;
                db.SaveChanges();
                Session["GirisID"] = kullanici.GirisID;
                return RedirectToAction("Index", "Home",new { id = kullanicilar.KullaniciID });
            }
            else
            {
                return View();
            }
            

        }


    }
}