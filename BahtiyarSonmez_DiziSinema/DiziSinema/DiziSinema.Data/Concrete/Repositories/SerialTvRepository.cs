using DiziSinema.Data.Abstract;
using DiziSinema.Data.Concrete.Context;
using DiziSinema.Entity.Concrete.Entitys;
using DiziSinema.Entity.Concrete.JunctionClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziSinema.Data.Concrete.Repositories
{
    public class SerialTvRepository : GenericRepository<SerialTv>, ISerialTvRepository
    {
        public SerialTvRepository(DiziSinemaDbContext _context) : base(_context)
        {
            
        }
        private DiziSinemaDbContext DiziSinemaDbContext 
        {
            get { return _dbContext as DiziSinemaDbContext; }
        }

        public async Task ClearSerialTvGenreAsync(int serialTvId, int[] genreIds)
        {
            List<SerialTvGenre> serialTvGenres = await DiziSinemaDbContext
                .SerialTvGenres
                .Where(sg => sg.SerialTvId == serialTvId)
                .ToListAsync();
            DiziSinemaDbContext.SerialTvGenres.RemoveRange(serialTvGenres);
            await DiziSinemaDbContext.SaveChangesAsync();
        }

        public async Task<List<SerialTv>> GetSerialTvsByGenreIdAsync(int genreId)
        {
            List<SerialTv> serialTvs = await DiziSinemaDbContext
                .SerialTvs
                .Include(s => s.SerialTvGenres)
                .ThenInclude(sg => sg.Genre)
                .Where(s => s.SerialTvGenres.Any(sg => sg.GenreId == genreId))
                .ToListAsync();
            return serialTvs;
        }
    }
}
