using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity GetById(TKey id);
        int Save(TEntity entity);
        void Update(TEntity entity);
        bool Delete(int id);
    }
}
