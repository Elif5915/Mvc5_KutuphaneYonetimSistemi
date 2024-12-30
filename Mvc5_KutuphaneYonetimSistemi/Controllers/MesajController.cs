using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5_KutuphaneYonetimSistemi.Models.Entity;

namespace Mvc5_KutuphaneYonetimSistemi.Controllers
{
    public class MesajController : Controller
    {
        // GET: Mesaj

        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var uyeMail = (string)Session["Mail"].ToString();
            var mesajlar = db.Mesajlar.Where(x => x.Alıcı == uyeMail.ToString()).ToList();
            return View(mesajlar);
        }

        public ActionResult GidenMesaj()
		{
            var uyeMail = (string)Session["Mail"].ToString();
            var mesajlar = db.Mesajlar.Where(x => x.Gonderen == uyeMail.ToString()).ToList();
            return View(mesajlar);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
		{
            return View();
		}

        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar mesajlar)
		{
            var uyeMail = (string)Session["Mail"].ToString();
            mesajlar.Gonderen = uyeMail.ToString();
            mesajlar.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Mesajlar.Add(mesajlar);
            db.SaveChanges();
            return RedirectToAction("GidenMesaj", "Mesaj");
		}
    }
}