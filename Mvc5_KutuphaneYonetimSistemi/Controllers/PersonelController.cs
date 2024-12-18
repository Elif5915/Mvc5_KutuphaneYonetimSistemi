using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5_KutuphaneYonetimSistemi.Models.Entity;

namespace Mvc5_KutuphaneYonetimSistemi.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var person = db.Personel.ToList();
            return View(person);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
			if (!ModelState.IsValid)
			{
                return View("PersonelEkle");
			}
            db.Personel.Add(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
		{
            var value = db.Personel.Find(id);
            db.Personel.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
		}
        public ActionResult PersonelGuncelleme(int id)
		{
            var personData = db.Personel.Find(id);
            return View("PersonelGuncelle", personData);
		}

        [HttpPost]
        public ActionResult PersonelGuncelleme(Personel personel)
		{
            var person = db.Personel.Find(personel.Id);
            person.Personel1 = personel.Personel1;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}