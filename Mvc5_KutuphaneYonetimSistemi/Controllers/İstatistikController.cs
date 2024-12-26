using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5_KutuphaneYonetimSistemi.Models.Entity;

namespace Mvc5_KutuphaneYonetimSistemi.Controllers
{
    public class İstatistikController : Controller
    {
        // GET: İstatistik
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var deger1 = db.Uyeler.Count();
            ViewBag.uye = deger1;
            var deger2 = db.Kitap.Count();
            ViewBag.kitap = deger2;
            var deger3 = db.Kitap.Where(x => x.Durum == false).Count();
            ViewBag.ekitap = deger3;
            var deger4 = db.Cezalar.Sum(x => x.Para);
            ViewBag.para = deger4;
            return View();
        }
        public ActionResult Hava()
		{
            return View();
		}
        public ActionResult HavaKart()
		{
            return View();
        }
        public ActionResult Galeri()
		{
            return View();
		}

        [HttpPost]
        public ActionResult ResimYukle(HttpPostedFileBase file)
		{
            if(file.ContentLength > 0)
			{
                string dosyaYol= Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(file.FileName));
                file.SaveAs(dosyaYol);
			}
            return RedirectToAction("Galeri");
		}

        public ActionResult LinqKart()
		{
            var deger1 = db.Kitap.Count();
            ViewBag.dgr1 =  deger1;
            var deger2 = db.Uyeler.Count();
            ViewBag.dgr2 = deger2;
            var deger3 = db.Cezalar.Sum(x => x.Para);
            ViewBag.dgr3 = deger3;
            var deger4 = db.Kitap.Where(z => z.Durum == false).Count();
            ViewBag.dgr4 = deger4;
            var deger8 = db.EnFazlaKitapYazar().FirstOrDefault(); //FirstOrDefault :  aynı şartı sağlayan  datalar/listeler dönenin ilk degeri al sadece 
            ViewBag.dgr8 = deger8;
            var deger9 = db.Kitap.GroupBy(x => x.YayınEvi).OrderByDescending(z => z.Count()).Select(y => new { y.Key }).FirstOrDefault();
            ViewBag.dgr9 = deger9;
            var deger11 = db.İletisim.Count();
             ViewBag.dgr11 = deger11;
            return View();
		}
    }
}