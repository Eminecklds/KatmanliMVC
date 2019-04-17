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
    public class AdresManager
    {
        //insert-update-delete işlemleri için buradan yönlendirilecek.
        //CRUD olarak geçer bu işlemler
        //Create,read,update,delete
        //Mesajlarımı buradan göreceğim
        AdresRepository _adresRepository;
        public AdresManager()
        {
            _adresRepository = new AdresRepository();

        }
        //newlemeişlemim her zaman constructor içerisinde olmalı
        public string AddAdres(Adres item)
        {
            //metodum string çünkü mesaj döndürmesini istiyorum
            try
            {
                _adresRepository.Add(item);
                return "Ekleme İşlemi Başarılı";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateAdres(Adres item)
        {
            try
            {
                _adresRepository.Update(item);
                return "Update İşlemi Başarılı";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public string DeleteAdres(Adres item)
        {
            try
            {
                _adresRepository.Delete(item);
                return "Silme İşlemi Başarılı";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public ICollection<Adres> GetAllAdres(Expression<Func<Adres, bool>> parameter = null)
        {
            return _adresRepository.GetAll(parameter);
        }


    }
}
