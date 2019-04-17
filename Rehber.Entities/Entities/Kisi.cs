using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.Entities.Entities
{
    public class Kisi
    {
        public int KisiID { get; set; }
        public string  Adi { get; set; }
        public string  Soyadi { get; set; }
        public int  Yas { get; set; }
        public virtual ICollection<Adres> Adres { get; set; }
    }
}
