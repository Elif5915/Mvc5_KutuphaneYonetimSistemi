using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5_KutuphaneYonetimSistemi.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        public ActionResult AdminLogin()
        {
            return View();
        }
    }
}