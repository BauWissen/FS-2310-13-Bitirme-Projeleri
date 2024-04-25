using IsKapisi.Data.Abstract;
using IsKapisi.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsKapisi.Data.Concrete
{
    public class JobRepository:GenericRepository<Job>,IJobRepository
    {
        public JobRepository(AppDbContext _appDbContext) : base(_appDbContext)
        {
            
        }
        AppDbContext AppContext
        {
            get
            {
                return _dbContext as AppDbContext;
            }
        }

        public List<Job> DeletedProducts(bool? isDeleted)
        {

            var jobs = AppContext
                .Jobs
                .Where(p => p.IsDelete == isDeleted)
                .ToList();
            return jobs;
        }

        public List<Job> GetDeletedJobs(bool? isDeleted)
        {

            var jobs = AppContext
                .Jobs
                .Where(p => p.IsDelete == isDeleted)
                .ToList();
            return jobs;
        }

        public List<Job> GetHomePageProducts(bool? isHome)
        {
            var jobs = AppContext
                .Jobs
                .Where(p => p.IsHome == isHome && p.IsActive && !p.IsDelete)
                .ToList();
            return jobs;
        }

        public List<Job> GetProductsByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
