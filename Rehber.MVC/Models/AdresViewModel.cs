using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rehber.MVC.Models
{
    public class AdresViewModel
    {
        public int AdresID { get; set; }
        [Required(ErrorMessage ="İl alanı boş geçilemez")]
        [MaxLength(20,ErrorMessage ="İl alanı maksimum 20 karakter olabilir")]
        public string Il { get; set; }
        [Required(ErrorMessage = "İlçe alanı boş geçilemez")]
        [MaxLength(20, ErrorMessage = "İlçe alanı maksimum 20 karakter olabilir")]
        public string Ilce { get; set; }
        public int KisiID { get; set; }
    }
}