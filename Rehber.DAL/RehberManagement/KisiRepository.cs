using Rehber.DAL.RehberRepository;
using Rehber.Entities.Context;
using Rehber.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.DAL.RehberManagement
{
    public class KisiRepository : IKisi
    {
        RehberDbContext _db;
        public KisiRepository()
        {
            _db = new RehberDbContext();
        }
        public void Add(Kisi item)
        {
            _db.Kisis.Add(item);
            _db.SaveChanges();
        }

        public void Delete(Kisi item)
        {
            _db.Kisis.Remove(item);
            _db.SaveChanges();
        }

        public ICollection<Kisi> GetAll(Expression<Func<Kisi, bool>> parameter = null)
        {
            return parameter == null ?
               _db.Kisis.ToList() :
               _db.Kisis.Where(parameter).ToList();
        }

        public void Update(Kisi item)
        {
            Kisi EskiKisi = _db.Kisis.Find(item.KisiID);
            EskiKisi.Adi = item.Adi;
            EskiKisi.Soyadi = item.Soyadi;
            EskiKisi.Yas = item.Yas;
            _db.SaveChanges();
        }
    }
}
