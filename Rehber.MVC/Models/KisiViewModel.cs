using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rehber.MVC.Models
{
    public class KisiViewModel
    {
        public int KisiID { get; set; }
        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        [MaxLength(50, ErrorMessage = "Ad alanı maksimum 50 karakter olabilir")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        [MaxLength(20, ErrorMessage = "Soyad alanı maksimum 20 karakter olabilir")]
        public string Soyadi { get; set; }
        [Required(ErrorMessage = "Yaş alanı boş geçilemez")]
        [Range(10,60, ErrorMessage = "Yaş alanı maksimum 10 ile 60 arasında olabilir")]
        public int Yas { get; set; }
    }
}