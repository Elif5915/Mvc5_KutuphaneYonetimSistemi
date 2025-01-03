using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Mvc5_KutuphaneYonetimSistemi.Models.Entity;

namespace Mvc5_KutuphaneYonetimSistemi.Controllers
{
    public class PanelController : Controller
    {
        // GET: Panel
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            var uyeMail = (string)Session["Mail"];
            var deger = db.Uyeler.FirstOrDefault(z => z.Mail == uyeMail);
            return View(deger);
        }

        [HttpPost]
        public ActionResult Index2(Uyeler uyeler)
		{
            var kullanici = (string)Session["Mail"];
            var uye = db.Uyeler.FirstOrDefault(x => x.Mail == kullanici);
            uye.Sifre = uyeler.Sifre;
            uye.Ad = uyeler.Ad;
            uye.Fotograf = uyeler.Fotograf;
            uye.Okul = uyeler.Okul;
            uye.KullaniciAdi = uyeler.KullaniciAdi;
            db.SaveChanges();

            return RedirectToAction("Index");
		}
        public ActionResult Kitaplarim()
		{
            var kullanici = (string)Session["Mail"];
            var id = db.Uyeler.Where(x => x.Mail == kullanici.ToString()).Select(y => y.Id).FirstOrDefault();
            var deger = db.Hareket.Where(x => x.Uye == id).ToList();
            return View(deger);
		}
        public ActionResult Duyurular()
		{
            var duyuruList = db.Duyuru.ToList();
            return View(duyuruList);
		}
        public ActionResult LogOut()
		{
            FormsAuthentication.SignOut(); //FormsAuthentication : using System.Web.Security; eklemek gerek, oturumu kapat dedim.
            return RedirectToAction("GirisYap","Login");
		}
    }
}