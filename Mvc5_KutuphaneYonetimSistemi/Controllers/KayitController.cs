using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5_KutuphaneYonetimSistemi.Models.Entity;

namespace Mvc5_KutuphaneYonetimSistemi.Controllers
{
    public class KayitController : Controller
    {
        // GET: Kayit
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        [HttpGet]
        public ActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(Uyeler uyeler)
		{
			if (!ModelState.IsValid)
			{
                return View("KayitOl");
			}
            db.Uyeler.Add(uyeler);
            db.SaveChanges();
            return View();
		}
    }
}