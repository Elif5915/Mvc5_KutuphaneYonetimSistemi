using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5_KutuphaneYonetimSistemi.Models.Entity;

namespace Mvc5_KutuphaneYonetimSistemi.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var values = db.Yazar.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult YazarEkle()
		{
            return View();
		}

        [HttpPost]
        public ActionResult YazarEkle(Yazar yazar)
		{
            db.Yazar.Add(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
		}
    }
}