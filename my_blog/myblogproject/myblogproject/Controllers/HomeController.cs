using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myblogproject.Models;
using PagedList;
using PagedList.Mvc;

namespace myblogproject.Controllers
{
    public class HomeController : Controller
    {


        [HttpPost]
        public ActionResult Begen(int makeleID)
        {
           
            
                var makale = db.Makale.Where(x => x.MakaleID == makeleID).SingleOrDefault();
                makale.Begeni = makale.Begeni + 1;
                db.SaveChanges();
                
            
            return View();



        }
        public ActionResult Kategori(int id)
        {
            var makaleler = db.Makale.Where(x => x.Kategori.KategoriID == id).ToList();
            return View(makaleler);
        }

        // GET: Home
        public ActionResult Index(int page=1)
        {
            var makale = db.Makale.OrderBy(x => x.MakaleID).ToPagedList(page,3);
            return View(makale);
        }

        public ActionResult MakaleDetay(int id)
        {
            var makale = db.Makale.Where(x => x.MakaleID==id).SingleOrDefault();

            return View(makale);

        }

        public ActionResult Hakkimda()
        {
            return View();
        }
        public ActionResult İletisim()
        {
            return View();
        }
        myblogDB db = new myblogDB();
        public ActionResult KategoriPartial()
        {
            return View(db.Kategori.ToList());
        }
    }
}