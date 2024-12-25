using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5_KutuphaneYonetimSistemi.Controllers
{
    public class İstatistikController : Controller
    {
        // GET: İstatistik
        public ActionResult Index()
        {
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
    }
}