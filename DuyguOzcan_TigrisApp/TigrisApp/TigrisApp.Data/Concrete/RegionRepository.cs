using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigrisApp.Data.Abstract;
using TigrisApp.Entity.Concrete;

namespace TigrisApp.Data.Concrete
{
    public class RegionRepository : GenericRepository<Region> , IRegionRepository
    {
        public RegionRepository(TigrisDbContext context) : base(context)
        {
            
        }
        private TigrisDbContext TigrisDbContext
        {
            get
            {
                return _dbContext as TigrisDbContext;
            }
        }
    }
}