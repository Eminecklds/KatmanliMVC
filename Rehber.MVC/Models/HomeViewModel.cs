using Rehber.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rehber.MVC.Models
{
    public class HomeViewModel
    {
        public ICollection<Adres> Adresler { get; set; }
        public ICollection<Kisi> Kisiler { get; set; }
    }
}