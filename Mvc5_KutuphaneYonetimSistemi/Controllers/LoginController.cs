using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5_KutuphaneYonetimSistemi.Models.Entity;
using System.Web.Security;

namespace Mvc5_KutuphaneYonetimSistemi.Controllers
{
    [AllowAnonymous] //bu komut attr. ile girisyap işlemimi global.asaxdaki authorize işleminden muaf tuttum.
    public class LoginController : Controller
    {
        // GET: Login
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(Uyeler uyeler)
        {
            var data = db.Uyeler.Where(x => x.Mail == uyeler.Mail && x.Sifre == uyeler.Sifre).FirstOrDefault();
            if(data != null)
			{
                FormsAuthentication.SetAuthCookie(data.Mail, false);
				//Session["Id"] = data.Id.ToString();
				Session["Ad"] = data.Ad.ToString();
				Session["Soyad"] = data.Soyad.ToString();
				//Session["KullaniciAd"] = data.KullaniciAdi.ToString();
				//Session["Sifre"] = data.Sifre.ToString();
				//Session["Okul"] = data.Okul.ToString();

				Session["mail"] = data.Mail.ToString();
                //TempData["Id"] = data.Id.ToString();
                //TempData["Ad"] = data.Ad.ToString();
                //TempData["Soyad"] = data.Soyad.ToString();
                //TempData["KullaniciAd"] = data.KullaniciAdi.ToString();
                //TempData["Sifre"] = data.Sifre.ToString();
                //TempData["Okul"] = data.Okul.ToString();

                return RedirectToAction("Index", "Panel");
			}
			else
			{
                return View();
            }
           
        }
    }
}