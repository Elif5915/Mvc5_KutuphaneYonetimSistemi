using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5_KutuphaneYonetimSistemi.Models.Entity;

namespace Mvc5_KutuphaneYonetimSistemi.Controllers
{
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var data = db.Duyuru.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult DuyuruEkle()
		{
            return View();
		}
        [HttpPost]
        public ActionResult DuyuruEkle(Duyuru duyuru)
        {
            db.Duyuru.Add(duyuru);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult DuyuruSil(int id)
		{
            var duyuru = db.Duyuru.Find(id);
            db.Duyuru.Remove(duyuru);
            db.SaveChanges();

            return RedirectToAction("Index");
		}

        public ActionResult DuyuruDetayGuncel(Duyuru duyuru)
		{
            var data = db.Duyuru.Find(duyuru.Id);
            return View("DuyuruDetayGuncel", data);

		}
 
        public ActionResult DuyuruGuncel(Duyuru duyuru)
        {
            var data = db.Duyuru.Find(duyuru.Id);
            data.Kategori = duyuru.Kategori;
            data.Tarih = duyuru.Tarih;
            data.Icerik = duyuru.Icerik;
            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}