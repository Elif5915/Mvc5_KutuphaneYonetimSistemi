using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5_KutuphaneYonetimSistemi.Models.Entity;

namespace Mvc5_KutuphaneYonetimSistemi.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index(string p)
        {
            var kitaplar = string.IsNullOrEmpty(p)
         ? db.Kitap.ToList()
         : db.Kitap.Where(k => k.Ad.Contains(p) ||
                               k.Yazar1.Ad.Contains(p) ||
                               k.Yazar1.Soyad.Contains(p) ||
                               k.Kategori1.Ad.Contains(p)).ToList();

            return View(kitaplar);
        }

        [HttpGet]
        public ActionResult KitapEkle()
		{
            List<SelectListItem> deger = db.Kategori
                                        .Select(i => new SelectListItem
                                        {
                                              Text = i.Ad,
                                              Value = i.Id.ToString()

                                        }).ToList();

            ViewBag.KategoriCombo = deger;

            List<SelectListItem> yazar = db.Yazar
                                         .Select(y => new SelectListItem
                                         {
                                             Text = y.Ad + " " + y.Soyad,
                                             Value = y.Id.ToString()

                                         }).ToList();
            ViewBag.YazarCombo = yazar;
            return View();
		}

        [HttpPost]
        public ActionResult KitapEkle(Kitap kitap)
        {
            var kategori = db.Kategori.Where(k => k.Id == kitap.Kategori1.Id).FirstOrDefault();
            var yazar = db.Yazar.Where(y => y.Id == kitap.Yazar1.Id).FirstOrDefault();
            kitap.Kategori1 = kategori;
            kitap.Yazar1 = yazar;
            db.Kitap.Add(kitap);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult KitapSil(int id)
		{
            var deleteBook = db.Kitap.Find(id);
            db.Kitap.Remove(deleteBook);
            db.SaveChanges();
            return RedirectToAction("Index");
		}
        public ActionResult KitapGetir(int id)
        {
            var value = db.Kitap.Find(id);
            List<SelectListItem> deger = db.Kategori
                                        .Select(i => new SelectListItem
                                        {
                                            Text = i.Ad,
                                            Value = i.Id.ToString()

                                        }).ToList();

            ViewBag.KategoriCombo = deger;
            List<SelectListItem> yazar = db.Yazar
                                      .Select(y => new SelectListItem
                                      {
                                          Text = y.Ad + " " + y.Soyad,
                                          Value = y.Id.ToString()

                                      }).ToList();
            ViewBag.YazarCombo = yazar;
            return View("KitapGetir", value);

        }

        public ActionResult KitapGuncelle(Kitap kitap)
		{
            var value = db.Kitap.Find(kitap.Id);
            value.Ad = kitap.Ad;
            value.BasımYıl = kitap.BasımYıl;
            value.YayınEvi = kitap.YayınEvi;
            value.Sayfa = kitap.Sayfa;

            var ktg = db.Kategori.Where(k => k.Id == kitap.Kategori1.Id).FirstOrDefault();
            var yzr = db.Yazar.Where(y => y.Id == kitap.Yazar1.Id).FirstOrDefault();

            value.Yazar = yzr.Id;
            value.Kategori = ktg.Id;

            db.SaveChanges();
            return RedirectToAction("Index");
		}
    }
}