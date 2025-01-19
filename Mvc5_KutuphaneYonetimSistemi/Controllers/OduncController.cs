using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5_KutuphaneYonetimSistemi.Models.Entity;

namespace Mvc5_KutuphaneYonetimSistemi.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        [Authorize(Roles = "A")] // sadece a rolüne sahip olanlar bu index sf görsün demiş olduk.
        public ActionResult Index()
        {
            //var values = db.Hareket.ToList();
            var values = db.Hareket.Where(x => x.IslemDurum == false).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult OduncVer()
		{
            List<SelectListItem> deger1 = (from x in db.Uyeler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Ad + " " + x.Soyad,
                                               Value = x.Id.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from y in db.Kitap.Where(y => y.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.Ad,
                                               Value = y.Id.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from z in db.Personel.ToList()
                                           select new SelectListItem
                                           {
                                               Text = z.Personel1,
                                               Value = z.Id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;


            return View();

        }
        [HttpPost]
        public ActionResult OduncVer(Hareket hareket)
		{
            var d1 = db.Uyeler.Where(x => x.Id == hareket.Uyeler.Id).FirstOrDefault();
            var d2 = db.Kitap.Where(y => y.Id == hareket.Kitap.Id).FirstOrDefault();
            var d3 = db.Personel.Where(z => z.Id == hareket.Personel1.Id).FirstOrDefault();

            hareket.Uyeler = d1;
            hareket.Kitap = d2;
            hareket.Personel1 = d3;

            db.Hareket.Add(hareket);
            db.SaveChanges();
            return RedirectToAction("Index");
           
		}

        public ActionResult OduncIade(Hareket hareket)
		{
            var data = db.Hareket.Find(hareket.Id);
            DateTime dt = DateTime.Parse(data.IadeTarihi.ToString());
            DateTime nw = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan farkTarih = nw - dt;
            ViewBag.dgr = farkTarih.TotalDays;
            return View("OduncIade", data);
		}
        [HttpPost]
        public ActionResult OduncGuncelle(Hareket hareket)
        {
            var data = db.Hareket.Find(hareket.Id);
            data.UyeGetirTarih = hareket.UyeGetirTarih;
            data.IslemDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}