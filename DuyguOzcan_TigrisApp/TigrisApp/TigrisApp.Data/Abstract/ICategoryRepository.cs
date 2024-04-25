using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigrisApp.Entity.Concrete;

namespace TigrisApp.Data.Abstract
{
    public interface ICategoryRepository :IGenericRepository<Category>
    {
        //buraya kategoriye özgü metotları yazacağız. tabi bu gerekiyorsa.
        Task<int> CountAsync();
    }
}