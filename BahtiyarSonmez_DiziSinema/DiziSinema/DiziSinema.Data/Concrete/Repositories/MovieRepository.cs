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
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(DiziSinemaDbContext _context ) : base (_context)
        {
            
        }
        private DiziSinemaDbContext DiziSinemaDbContext
        {
            get { return _dbContext as DiziSinemaDbContext; }
        }

        public async Task CleaarMovieGenreAsync(int movieId, int[] genreIds)
        {
            List<MovieGenre> movieGenres = await DiziSinemaDbContext
                .MovieGenres
                .Where(mg => mg.MovieId == movieId)
                .ToListAsync();
            DiziSinemaDbContext.MovieGenres.RemoveRange(movieGenres);
            await DiziSinemaDbContext.SaveChangesAsync();
        }

        public async Task<List<Movie>> GetMoviesByGenreIdAsync(int genreId)
        {
            List<Movie> Movies = await DiziSinemaDbContext
                .Movies
                .Include(m => m.MovieGenres)
                .ThenInclude(mg => mg.Genre)
                .Where(m => m.MovieGenres.Any(mg => mg.GenreId == genreId))
                .ToListAsync();
            return Movies;
        }
    }
}
