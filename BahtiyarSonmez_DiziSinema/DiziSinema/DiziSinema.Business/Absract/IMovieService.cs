using DiziSinema.Shared.DTOs;
using DiziSinema.Shared.DTOs.Core.Add;
using DiziSinema.Shared.DTOs.Core.Edit;
using DiziSinema.Shared.ReponseDTOs;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DiziSinema.Business.Absract
{
    public interface IMovieService
    {
        #region Generic
        Task<Response<MovieDTO>> GetByIdAsync(int id);
        Task<Response<List<MovieDTO>>> GetAllAsync();
        Task<Response<List<MovieDTO>>> GetAllNonDeletedAsync(bool id = false);
        Task<Response<MovieDTO>> CreateAsync(AddMovieDTO addMovieDTO);
        Task<Response<MovieDTO>> UpdateAsync(EditMovieDTO editMovieDTO);
        Task<Response<NoContent>> HardDeleteAsync(int id);
        Task<Response<NoContent>> SoftDeleteAsync(int id);
        #endregion

        #region Movie
        Task<Response<NoContent>> UpdateIsActiveAsync(int id);
        Task<Response<int>> GetActiveMovieCount();
        Task<Response<int>> GetMovieCount();
        Task<Response<MovieDTO>> GetMovieWithGenresAsync(int id);
        Task<Response<List<MovieDTO>>> GetMoviesByGenreIdAsync (int genreId);
        Task<Response<List<MovieDTO>>> GetAllMoviesWithGenresAsync ();
        #endregion
    }
}