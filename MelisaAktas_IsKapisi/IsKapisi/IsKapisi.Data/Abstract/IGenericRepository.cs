using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsKapisi.Data.Abstract
{
    public interface IGenericRepository<TEntity>
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void HardDelete(TEntity entity);
        void SoftDelete(TEntity entity);
    }
}
