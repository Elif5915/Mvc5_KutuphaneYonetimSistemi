using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Mvc5_KutuphaneYonetimSistemi.Models.Entity;

namespace Mvc5_KutuphaneYonetimSistemi.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var values = db.Admin.FirstOrDefault(x => x.Kullanici == admin.Kullanici && x.Sifre == admin.Sifre);
            if (values != null)
			{
                FormsAuthentication.SetAuthCookie(values.Kullanici, false);
                Session["Kullanici"] = values.Kullanici.ToString();
                return RedirectToAction("Index", "İstatistik");
			}
			else
			{
                return View();
            }
            
        }

    }
}