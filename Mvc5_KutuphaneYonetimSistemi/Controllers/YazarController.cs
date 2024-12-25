using Mvc5_KutuphaneYonetimSistemi.Models.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Mvc5_KutuphaneYonetimSistemi.Controllers
{
	public class YazarController : Controller
	{
		// GET: Yazar
		DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
		public ActionResult Index()
		{
			var values = db.Yazar.ToList();
			return View(values);
		}

		[HttpGet]
		public ActionResult YazarEkle()
		{
			return View();
		}

		[HttpPost]
		public ActionResult YazarEkle(Yazar yazar)
		{
			if (!ModelState.IsValid) //model üzerinde yapmış olduğum geçerleme/validate işlemi yapılmamış ise kurala uygun kayıt işlemi yapılamasın 
			{
				return View("YazarEkle");
			}
			db.Yazar.Add(yazar);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult YazarSil(int id)
		{
			var value = db.Yazar.Find(id);
			db.Yazar.Remove(value);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult YazarGetir(int id)
		{
			var value = db.Yazar.Find(id);
			return View("YazarGetir", value);
		
		}

		[HttpPost]
		public ActionResult YazarGuncelle(Yazar y)
		{
			var value = db.Yazar.Find(y.Id);
			value.Ad = y.Ad;
			value.Soyad = y.Soyad;
			value.Detay = y.Detay;
			db.SaveChanges();
			return RedirectToAction("Index");
		}


	}
}