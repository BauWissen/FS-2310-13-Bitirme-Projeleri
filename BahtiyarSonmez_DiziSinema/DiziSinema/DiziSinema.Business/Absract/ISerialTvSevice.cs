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
    public interface ISerialTvSevice
    {
        #region Generic
        Task<Response<SerialTvDTO>> GetByIdAsync(int id);
        Task<Response<List<SerialTvDTO>>> GetAllAsync();
        Task<Response<List<SerialTvDTO>>> GetAllNonDeletedAsync(bool id = false);
        Task<Response<SerialTvDTO>> CreateAsync(AddSerialTvDTO addSerialTvDTO);
        Task<Response<SerialTvDTO>> UpdateAsync(EditSerialTvDTO editSerialTvDTO);
        Task<Response<NoContent>> HardDeleteAsync(int id);
        Task<Response<NoContent>> SoftDeleteAsync(int id);
        #endregion

        #region SerialTv
        Task<Response<NoContent>> UpdateIsActiveAsync(int id);
        Task<Response<int>> GetActiveSerialTvCount();
        Task<Response<int>> GetSerialTvCount();
        Task<Response<SerialTvDTO>> GetSerialTvWithGenresAsync(int id);
        Task<Response<List<SerialTvDTO>>> GetSerialTvsByGenreIdAsync(int genreId);
        Task<Response<List<SerialTvDTO>>> GetAllSerialTvsWithGenresAsync();
        #endregion
    }
}
