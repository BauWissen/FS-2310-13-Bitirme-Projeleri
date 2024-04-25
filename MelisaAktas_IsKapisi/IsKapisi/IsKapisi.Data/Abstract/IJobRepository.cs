using IsKapisi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsKapisi.Data.Abstract
{
    public interface IJobRepository:IGenericRepository<Job>
    {
        List<Job> GetProductsByCategoryId(int categoryId);
        List<Job> GetHomePageProducts(bool? isHome);

        List<Job>GetDeletedJobs(bool? isDeleted);


    }
}
