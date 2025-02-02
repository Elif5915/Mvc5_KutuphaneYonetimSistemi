﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Mvc5_KutuphaneYonetimSistemi
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			GlobalFilters.Filters.Add(new AuthorizeAttribute()); //bu kod satırı ile eğer auth giriş yapılmadıysa hiçbir şekilde sisteme giriş yapılmasın dedik.Proje bazında authorize işlemi bu.burada kısıtlama da yaptırabilirsin.
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
	}
}
