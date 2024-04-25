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
    public interface IGenreService
    {
        #region Generic
        Task<Response<GenreDTO>> GetByIdAsync(int id);
        Task<Response<List<GenreDTO>>> GetAllAsync();
        Task<Response<GenreDTO>> CreateAsync(AddGenreDTO addGenreDTO);
        Task<Response<GenreDTO>> UpdateAsync(EditGenreDTO editGenreDTO);
        Task<Response<NoContent>> HardDeleteAsync(int id);
        Task<Response<NoContent>> SoftDeleteAsync(int id);
        #endregion

        #region Genre
        Task<Response<List<GenreDTO>>> GetActiveGenre(bool isActive = true);
        Task<Response<List<GenreDTO>>> GetNonDeletedGenre(bool isDeleted = false);
        Task<Response<int>> GetActiveGenreCount();
        Task<Response<int>> GetGenreCount();
        Task<Response<List<GenreDTO>>> GetGenres();
        #endregion
    }
}
