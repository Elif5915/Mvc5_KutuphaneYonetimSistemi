using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5_KutuphaneYonetimSistemi.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace Mvc5_KutuphaneYonetimSistemi.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index(int sayfa = 1)
        {
            //var value = db.Uyeler.ToList();
            var degerler = db.Uyeler.ToList().ToPagedList(sayfa,3);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UyeEkle()
		{
            return View();
		}

        [HttpPost]
        public ActionResult UyeEkle(Uyeler uyeler)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.Uyeler.Add(uyeler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeSil(int id)
		{
            var value = db.Uyeler.Find(id);
            db.Uyeler.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
		}

        public ActionResult UyeGuncelle(int id)
        {
            var value = db.Uyeler.Find(id);
            return View("UyeGuncelle", value);
        }

        [HttpPost]
        public ActionResult UyeGuncelle(Uyeler uyeler)
        {
            var uyeData = db.Uyeler.Find(uyeler.Id);
            uyeData.Ad = uyeler.Ad;
            uyeData.Soyad = uyeler.Soyad;
            uyeData.Mail = uyeler.Mail;
            uyeData.KullaniciAdi = uyeler.KullaniciAdi;
            uyeData.Sifre = uyeler.Sifre;
            uyeData.Fotograf = uyeler.Fotograf;
            uyeData.Telefon = uyeler.Telefon;
            uyeData.Okul = uyeler.Okul;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeKitapGecmis(int id)
		{
            var data = db.Hareket.Where(x => x.Uye == id).ToList();
            var uyeKitap = db.Uyeler.Where(y => y.Id == id).Select(z => z.Ad + " " + z.Soyad).FirstOrDefault();
            ViewBag.uyeBilgi = uyeKitap;
            return View(data);
		}
    }
}