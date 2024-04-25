using DiziSinema.Data.Abstract;
using DiziSinema.Data.Concrete.Context;
using DiziSinema.Entity.Concrete.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziSinema.Data.Concrete.Repositories
{
    public class GenreRepoitory: GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepoitory(DiziSinemaDbContext _context) : base(_context)
        {
            
        }

        private DiziSinemaDbContext DiziSinemaDbContext 
        { 
            get { return _dbContext as DiziSinemaDbContext; } 
        }

        public async Task<List<Genre>> GetGenres()
        {
            List<Genre> genres = await DiziSinemaDbContext
                .Genres
                .Where(c => c.IsActive && !c.IsDeleted)
                .ToListAsync();
            return genres;
        }
    }
}
