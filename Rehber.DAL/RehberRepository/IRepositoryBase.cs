using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.DAL.RehberRepository
{
    public interface IRepositoryBase<TEntity>where TEntity:class
    {
        //ekleme,silme,günceleme,listeleme
        //Yukarıdaki işlemlerin iskeletini vermiş oluyorum
        void Add(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
        //listeleme için özelleşiyor, sebebi de classın içerisindeki tüm veriyi ICollection yani liste olarak dönmek istediği için
        ICollection<TEntity>GetAll(Expression<Func<TEntity,bool>>parameter=null);
    }
}
