using AutoMapper;
using DiziSinema.Business.Absract;
using DiziSinema.Data.Abstract;
using DiziSinema.Entity.Concrete.Entitys;
using DiziSinema.Shared.DTOs;
using DiziSinema.Shared.DTOs.Core.Add;
using DiziSinema.Shared.DTOs.Core.Edit;
using DiziSinema.Shared.DTOs.In;
using DiziSinema.Shared.ReponseDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziSinema.Business.Concrete
{
    public class GenreManager : IGenreService
    {
        private readonly IMapper _mapper;
        private readonly IGenreRepository _repository;

        public GenreManager(IMapper mapper, IGenreRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<GenreDTO>> CreateAsync(AddGenreDTO addGenreDTO)
        {
            var genre = _mapper.Map<Genre>(addGenreDTO);
            var addGenre = await _repository.CreateAsync(genre);
            if (addGenre == null)
            {
                return Response<GenreDTO>.Fail("Film Oluşturulamadı", 301);
            }
            var addGenreDto = _mapper.Map<GenreDTO>(addGenre);
            return Response<GenreDTO>.Success(addGenreDto, 200);
        }

        public async Task<Response<GenreDTO>> UpdateAsync(EditGenreDTO editGenreDTO)
        {
            var editedGenre = _mapper.Map<Genre>(editGenreDTO);
            if (editedGenre == null)
            {
                return Response<GenreDTO>.Fail("Böyle Bir Tür Bulunamadı", 404);
            }
            editedGenre.ModifiedDate = DateTime.Now;
            await _repository.UpdateAsync(editedGenre);
            var editedGenreDto = _mapper.Map<GenreDTO>(editedGenre);
            return Response<GenreDTO>.Success(editedGenreDto, 200);
        }

        public async Task<Response<NoContent>> HardDeleteAsync(int id)
        {
            var genre = await _repository.GetByIdAsync(c => c.Id == id);
            if (genre == null)
            {
                return Response<NoContent>.Fail("ilgili tür bulunamadı.", 404);
            }
            await _repository.HardDeleteAsync(genre);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<NoContent>> SoftDeleteAsync(int id)
        {
            var deletedGenre = await _repository.GetByIdAsync(c => c.Id == id);
            if (deletedGenre == null)
            {
                return Response<NoContent>.Fail("ilgili tür Bulunamadı.", 404);
            }
            if (deletedGenre.IsDeleted)
            {
                return Response<NoContent>.Fail("Bu tür Zaten Silinmiş.", 404);
            }
            deletedGenre.IsDeleted = true;
            deletedGenre.IsActive = false;
            deletedGenre.ModifiedDate = DateTime.Now;
            await _repository.UpdateAsync(deletedGenre);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<GenreDTO>> GetByIdAsync(int id)
        {
            var genre = await _repository.GetByIdAsync(g => g.Id == id, source => source
            .Include(m => m.MovieGenres)
            .ThenInclude(mg => mg.Movie)
            .Include(s => s.SerialTvGenres)
            .ThenInclude(sg => sg.SerialTv));
            if (genre == null)
            {
                return Response<GenreDTO>.Fail("ilgili tür bulunamadı.", 404);
            }
            var genreDto = _mapper.Map<GenreDTO>(genre);
            return Response<GenreDTO>.Success(genreDto, 200);
        }

        public async Task<Response<List<GenreDTO>>> GetAllAsync()
        {
            var genreList = await _repository.GetAllAsync();
            if (genreList.Count == 0)
            {
                return Response<List<GenreDTO>>.Fail("Hiç tür bulunamadı", 301);
            }
            var genreDtoList = _mapper.Map<List<GenreDTO>>(genreList);
            return Response<List<GenreDTO>>.Success(genreDtoList, 200);
        }

        public async Task<Response<List<GenreDTO>>> GetActiveGenre(bool isActive = true)
        {
            var GenreList = await _repository.GetAllAsync(g => g.IsActive == isActive && g.IsDeleted == !isActive);
            string status = isActive ? "aktif" : "aktif olmayan";
            if (GenreList.Count == 0)
            {
                return Response<List<GenreDTO>>.Fail($"Hiç {status} Tür Bulunamadı", 301);
            }
            var GenreDtoList = _mapper.Map<List<GenreDTO>>(GenreList);
            return Response<List<GenreDTO>>.Success(GenreDtoList, 200);

        }

        public async Task<Response<List<GenreDTO>>> GetNonDeletedGenre(bool isDeleted = false)
        {
            var genreList = await _repository.GetAllAsync(g => g.IsDeleted == isDeleted);
            string status = isDeleted ? "silinmiş" : "silinmemiş";
            if (genreList.Count == 0)
            {
                return Response<List<GenreDTO>>.Fail($"Hiç {status} Tür Bulunamadı", 301);
            }
            var genreDtoList = _mapper.Map<List<GenreDTO>>(genreList);
            return Response<List<GenreDTO>>.Success(genreDtoList, 200);
        }

        public async Task<Response<int>> GetActiveGenreCount()
        {
            var count = await _repository.GetCountAsync(c => c.IsActive && !c.IsDeleted);
            return Response<int>.Success(count, 200);
        }

        public async Task<Response<int>> GetGenreCount()
        {
            var count = await _repository.GetCountAsync(c => !c.IsDeleted);
            return Response<int>.Success(count, 200);
        }

        public async Task<Response<List<GenreDTO>>> GetGenres()
        {
            var genreList = await _repository.GetGenres();
            if (genreList.Count == 0)
            {
                return Response<List<GenreDTO>>.Fail($"Hiç kategori bulunamadı",404);
            }
            var genreDtoList = _mapper.Map<List<GenreDTO>>(genreList);
            return Response<List<GenreDTO>>.Success(genreDtoList,200);
        }
    }
}
