using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TigrisApp.Data.Abstract;
using TigrisApp.Entity.Concrete;

namespace TigrisApp.Data.Concrete
{
    public class CategoryRepository : GenericRepository<Category> ,ICategoryRepository
    {
        public CategoryRepository(TigrisDbContext context) : base(context)
        {
            
        }
        private TigrisDbContext TigrisDbContext { get {
            return _dbContext as TigrisDbContext;
        }}
        public async Task<int> CountAsync()
        {
           return await TigrisDbContext.Categories.CountAsync();
        }
    }
}