using Rehber.DAL.RehberManagement;
using Rehber.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.DAL.KisiService
{
    public class KisiManager
    {
        KisiRepository _kisiRepository;
        public KisiManager()
        {
            _kisiRepository = new KisiRepository();

        }
        //newlemeişlemim her zaman constructor içerisinde olmalı
        public string AddKisi(Kisi item)
        {
            //metodum string çünkü mesaj döndürmesini istiyorum
            try
            {
                _kisiRepository.Add(item);
                return "Ekleme İşlemi Başarılı";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateKisi(Kisi item)
        {
            try
            {
                _kisiRepository.Update(item);
                return "Update İşlemi Başarılı";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string DeleteKisi(Kisi item)
        {
            try
            {
                _kisiRepository.Delete(item);
                return "Silme İşlemi Başarılı";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public ICollection<Kisi> GetAllKisi(Expression<Func<Kisi, bool>> parameter = null)
        {
            return _kisiRepository.GetAll(parameter);
        }
    }
}
