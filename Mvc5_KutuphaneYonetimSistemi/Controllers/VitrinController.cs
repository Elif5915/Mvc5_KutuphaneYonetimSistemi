using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5_KutuphaneYonetimSistemi.Models.Entity;
using Mvc5_KutuphaneYonetimSistemi.Models.Classes;

namespace Mvc5_KutuphaneYonetimSistemi.Controllers
{
    public class VitrinController : Controller
    {
        // GET: Vitrin
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.Kitap.ToList();
            cs.Deger2 = db.Hakkimizda.ToList();
           // var data = db.Kitap.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(İletisim iletisim)
		{
            db.İletisim.Add(iletisim);
            db.SaveChanges();
            return RedirectToAction("Index");
		}
    }
}