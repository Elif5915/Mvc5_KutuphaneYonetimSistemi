using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5_KutuphaneYonetimSistemi.Models;
using Mvc5_KutuphaneYonetimSistemi.Models.Entity;

namespace Mvc5_KutuphaneYonetimSistemi.Controllers
{
    public class GrafikController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeKitapResult()
		{
            return Json(liste());
		}

        public List<Class1> liste()
		{
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                yayinevi = "Çiçek",
                sayi = 7
            }) ;
            cs.Add(new Class1()
            {
                yayinevi = "Güneş",
                sayi = 2
            });
            cs.Add(new Class1()
            {
                yayinevi = "Yıldız",
                sayi = 5
            });

            return cs;  
        }
    }
}