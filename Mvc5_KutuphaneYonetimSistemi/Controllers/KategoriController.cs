using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5_KutuphaneYonetimSistemi.Models.Entity;

namespace Mvc5_KutuphaneYonetimSistemi.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var value = db.Kategori.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
		{
            return View();
		}

        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
		{
            db.Kategori.Add(kategori);
            db.SaveChanges();
            //return RedirectToAction("Index");
            return View();
		}
        public ActionResult KategoriSil(int id)
		{
            var kategori = db.Kategori.Find(id);
            db.Kategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
		}

        public ActionResult KategoriGuncelle(int id)
		{
            var value = db.Kategori.Find(id);
            return View("KategoriGüncelle", value);
		}
        [HttpPost]
        public ActionResult KategoriGuncelle(Kategori kategori)
		{
            var ktg = db.Kategori.Find(kategori.Id);
            ktg.Ad = kategori.Ad;
            db.SaveChanges();
            return RedirectToAction("Index");
		}


    }
}