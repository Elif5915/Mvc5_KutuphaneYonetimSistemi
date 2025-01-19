using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5_KutuphaneYonetimSistemi.Models.Entity;

namespace Mvc5_KutuphaneYonetimSistemi.Controllers
{
    public class AyarlarController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
 
        public ActionResult Index2()
        {
            var kullanicilar = db.Admin.ToList();
            return View(kullanicilar);
        }

        [HttpGet]
        public ActionResult YeniAdmin()
		{
            return View();
		}

        [HttpPost]
        public ActionResult YeniAdmin(Admin admin)
        {
            db.Admin.Add(admin);
            db.SaveChanges();
            return RedirectToAction("Index2");
          
        }

        public ActionResult DeleteAdmin(int id)
		{
            var admin = db.Admin.Find(id);
            db.Admin.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index2");

        }
        
       // [HttpGet]
        public ActionResult UpdateAdmin(int id)
		{
            var admin = db.Admin.Find(id);
            return View();
        }

        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin)
        {
            var data = db.Admin.Find(admin.Id);
            data.Kullanici = admin.Kullanici;
			data.Sifre = admin.Sifre;
            data.Yetki = admin.Yetki;
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
    }
}