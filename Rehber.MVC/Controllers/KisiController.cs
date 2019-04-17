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
    public class KisiController : Controller
    {
        // GET: Kisi
        KisiManager _kisiManager;
        public KisiController()
        {
            _kisiManager = new KisiManager();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult KisiEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KisiEkle(KisiViewModel kisiVM)
        {

            string mesaj = _kisiManager.AddKisi(new Kisi { Adi = kisiVM.Ad, Soyadi = kisiVM.Soyadi, Yas = kisiVM.Yas });
            TempData["Message"] = mesaj;

            return RedirectToAction("../Home/Index");
        }

        [HttpGet]
        public ActionResult KisiGuncelle(int id)
        {
            var kisi = _kisiManager.GetAllKisi(x => x.KisiID == id);
            KisiViewModel k = new KisiViewModel
            {
                KisiID = kisi.FirstOrDefault().KisiID,
                Ad = kisi.FirstOrDefault().Adi,
                Soyadi = kisi.FirstOrDefault().Soyadi,
                Yas = kisi.FirstOrDefault().Yas
            };
            return View(k);
        }
        [HttpPost]
        public ActionResult KisiGuncelle(KisiViewModel k)
        {
            Kisi kisi = new Kisi
            {
                KisiID = k.KisiID,
                Adi = k.Ad,
                Soyadi = k.Soyadi,
                Yas = k.Yas
            };
            TempData["Message"] = _kisiManager.UpdateKisi(kisi);
            return RedirectToAction("../Home/Index");
        }
        [HttpGet]
        public ActionResult KisiSil(int id)
        {
            var kisi = _kisiManager.GetAllKisi(x => x.KisiID == id);
            KisiViewModel k = new KisiViewModel
            {
                KisiID = kisi.FirstOrDefault().KisiID,
                Ad = kisi.FirstOrDefault().Adi,
                Soyadi = kisi.FirstOrDefault().Soyadi,
                Yas = kisi.FirstOrDefault().Yas
            };
            return View(k);
        }
        [HttpPost]
        [ActionName("KisiSil")]
        public ActionResult KisiSilinsinMi(int id)
        {

            Kisi kisi = _kisiManager.GetAllKisi(x => x.KisiID == id).FirstOrDefault();
            TempData["Message"] = _kisiManager.DeleteKisi(kisi);
            return RedirectToAction("../Home/Index");
        }
    }
}