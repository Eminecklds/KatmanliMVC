using Rehber.DAL.KisiService;
using Rehber.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rehber.MVC.Controllers
{
    public class HomeController : Controller
    {

        KisiManager _kisiManager;
        AdresManager _adresManager;
        // GET: Home
        public HomeController()
        {
            _kisiManager = new KisiManager();
            _adresManager = new AdresManager();
        }
        public ActionResult Index()
        {
            HomeViewModel hm = new HomeViewModel();
            hm.Kisiler = _kisiManager.GetAllKisi();
            hm.Adresler = _adresManager.GetAllAdres();
            return View(hm);
        }
    }
}