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
        public ActionResult Index()
        {
            //var values = db.Hareket.ToList();
            var values = db.Hareket.Where(x => x.IslemDurum == false).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult OduncVer()
		{
            return View();
		}
        [HttpPost]
        public ActionResult OduncVer(Hareket hareket)
		{
            db.Hareket.Add(hareket);
            db.SaveChanges();
            return View();
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