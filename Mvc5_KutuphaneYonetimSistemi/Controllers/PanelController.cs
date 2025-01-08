using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Mvc5_KutuphaneYonetimSistemi.Models.Entity;

namespace Mvc5_KutuphaneYonetimSistemi.Controllers
{
    [Authorize] //buraya eklersek bu controller içerisindeki tüm metodlarda auth. uygula demiş oluruz.Yani controller bazında auth. işlemi bu
    public class PanelController : Controller
    {
        // GET: Panel
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        // [Authorize] method bazında auth. işlemidir
        [HttpGet]
        public ActionResult Index()
        {
            var uyeMail = (string)Session["Mail"];
            //var deger = db.Uyeler.FirstOrDefault(z => z.Mail == uyeMail);
            var deger = db.Duyuru.ToList();

            var name = db.Uyeler.Where(x => x.Mail == uyeMail).Select(z => z.Ad).FirstOrDefault();
            ViewBag.Name = name;
            var surname = db.Uyeler.Where(y => y.Mail == uyeMail).Select(z => z.Soyad).FirstOrDefault();
            ViewBag.SurName = surname;
            var image = db.Uyeler.Where(y => y.Mail == uyeMail).Select(z => z.Fotograf).FirstOrDefault();
            ViewBag.Image = image;
            var username = db.Uyeler.Where(y => y.Mail == uyeMail).Select(z => z.KullaniciAdi).FirstOrDefault();
            ViewBag.UserName = username;
            var school = db.Uyeler.Where(y => y.Mail == uyeMail).Select(z => z.Okul).FirstOrDefault();
            ViewBag.School = school;
            var phone = db.Uyeler.Where(y => y.Mail == uyeMail).Select(z => z.Telefon).FirstOrDefault();
            ViewBag.Phone = phone;
            var mail = db.Uyeler.Where(y => y.Mail == uyeMail).Select(z => z.Mail).FirstOrDefault();
            ViewBag.Mail = mail;

            var uyeId = db.Uyeler.Where(z => z.Mail == uyeMail).Select(x => x.Id).FirstOrDefault();
            var topKitap = db.Hareket.Where(x => x.Uye == uyeId).Count();
            ViewBag.Kitap = topKitap;

            var topMesaj = db.Mesajlar.Where(x => x.Alıcı == uyeMail).Count();
            ViewBag.Mesaj = topMesaj;

            var duyuru = db.Duyuru.Count();
            ViewBag.Duyuru = duyuru;

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

       // [Authorize]
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
        public PartialViewResult PartialActivity()
		{
            return PartialView();
		}
    }
}