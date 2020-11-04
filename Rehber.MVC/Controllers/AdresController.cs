using Rehber.DAL.KisiService;
using Rehber.Entities.Entities;
using Rehber.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rehber.MVC.Controllers
{
    public class AdresController : Controller
    {
        // GET: Adres
        AdresManager _adresManager;
        KisiManager _kisiManager;
        public AdresController()
        {
            _adresManager = new AdresManager();
            _kisiManager = new KisiManager();
        }

        //Kişileri getiren bir dropdown yapıp
        //ViewBag ile sayfama taşıma işlemi yapıcam
        public List<SelectListItem> DropDownDoldur()
        {
            List<SelectListItem> kisiListesi = (from p in _kisiManager.GetAllKisi().ToList()
                                            select new SelectListItem
                                            {
                                                Text = p.Adi + " " + p.Soyadi,
                                                Value = p.KisiID.ToString()
                                            }).ToList();
            return kisiListesi;

        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AdresEkle()
        {
            ViewBag.KisiListesi = DropDownDoldur();
            return View();
        }
        [HttpPost]
        public ActionResult AdresEkle(AdresViewModel adresvm)
        {

            TempData["Message"] = _adresManager.AddAdres(new Adres {
                Il = adresvm.Il,
                Ilce=adresvm.Ilce,
                KisiID=adresvm.KisiID
            
            });
            return RedirectToAction("../Home/Index");
        }



        //Güncelleme işlemi için sayfaya verilerimi çekicek kısım
        [HttpGet]
        public ActionResult AdressGuncelle(int Id)// As per coding guidlin Id should be id so its look like  public ActionResult AdressGuncelle(int id)
        {
            ViewBag.KisiListesi = DropDownDoldur();
            var adres = _adresManager.GetAllAdres(x => x.AdresID == Id);
            AdresViewModel adrsvm = new AdresViewModel
            {
                AdresID = adres.FirstOrDefault().AdresID,
                Il = adres.FirstOrDefault().Il,
                Ilce = adres.FirstOrDefault().Ilce,
                KisiID = adres.FirstOrDefault().KisiID
            };
            return View(adrsvm);
        }
        [HttpPost]
        public ActionResult AdressGuncelle(AdresViewModel adresvm)
        {
            Adres ad = new Adres
            {
                AdresID = adresvm.AdresID,
                Il = adresvm.Il,
                Ilce = adresvm.Ilce,
                KisiID = adresvm.KisiID
            };
            TempData["Message"] = _adresManager.UpdateAdres(ad);
            return RedirectToAction("../Home/Index");
        }
        [HttpGet]
        public ActionResult AdresSil(int id)
        {
            var adres = _adresManager.GetAllAdres(x => x.AdresID == id);
            AdresViewModel ads = new AdresViewModel
            {
                AdresID = adres.FirstOrDefault().AdresID,
                Il = adres.FirstOrDefault().Il,
                Ilce = adres.FirstOrDefault().Ilce,
                KisiID = adres.FirstOrDefault().KisiID
            };
            var Kisi = _kisiManager.GetAllKisi(x => x.KisiID == ads.KisiID).FirstOrDefault();
            ViewBag.AdSoyad = Kisi.Adi + " " + Kisi.Soyadi;
            return View(ads);
        }
        [HttpPost]
        [ActionName("AdresSil")]
        public ActionResult AdressSilinsinMi(int id)
        {
            Adres adres = _adresManager.GetAllAdres(x => x.AdresID == id).FirstOrDefault();
            TempData["Message"] = _adresManager.DeleteAdres(adres);
            return RedirectToAction("../Home/Index");
        }
        
    }
}
