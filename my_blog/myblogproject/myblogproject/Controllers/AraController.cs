using myblogproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myblogproject.Controllers
{
    public class AraController : Controller
    {
        myblogDB db = new myblogDB();
        // GET: Ara
        public ActionResult Arama(string Ara=null)
        {
            var makale = db.Makale.Where(x => x.Baslik.Contains(Ara)).ToList();
            return View(makale);
        }

    }
}