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
    public class SerialTvManager : ISerialTvSevice
    {
        private readonly IMapper _mapper;
        private readonly ISerialTvRepository _repository;

        public SerialTvManager(IMapper mapper, ISerialTvRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<SerialTvDTO>> CreateAsync(AddSerialTvDTO addSerialTvDTO)
        {
            var serialTv = _mapper.Map<SerialTv>(addSerialTvDTO);
            var addSerialTv = await _repository.CreateAsync(serialTv);
            if (addSerialTv == null)
            {
                return Response<SerialTvDTO>.Fail("Dizi Oluşturulamadı", 301);
            }
            var addSerialDto = _mapper.Map<SerialTvDTO>(addSerialTv);
            return Response<SerialTvDTO>.Success(addSerialDto, 200);
        }

        public async Task<Response<SerialTvDTO>> UpdateAsync(EditSerialTvDTO editSerialTvDTO)
        {
            var editedSerialTv = _mapper.Map<SerialTv>(editSerialTvDTO);
            if (editedSerialTv == null)
            {
                return Response<SerialTvDTO>.Fail("Böyle Bir Dizi Bulunamadı", 404);
            }
            editedSerialTv.ModifiedDate = DateTime.Now;
            await _repository.UpdateAsync(editedSerialTv);
            await _repository.ClearSerialTvGenreAsync(editedSerialTv.Id, editSerialTvDTO.GenreIds);
            editedSerialTv.SerialTvGenres = editSerialTvDTO
                .GenreIds
                .Select(genId => new Entity.Concrete.JunctionClasses.SerialTvGenre
                {
                    SerialTvId = editedSerialTv.Id,
                    GenreId = genId
                }).ToList();
            await _repository.UpdateAsync(editedSerialTv);
            var editedSerialTvDto = _mapper.Map<SerialTvDTO>(editedSerialTv);
            return Response<SerialTvDTO>.Success(editedSerialTvDto, 200);
        }

        public async Task<Response<NoContent>> HardDeleteAsync(int id)
        {
            var serialTv = await _repository.GetByIdAsync(c => c.Id == id);
            if (serialTv == null)
            {
                return Response<NoContent>.Fail("ilgili Dizi bulunamadı.", 404);
            }
            await _repository.HardDeleteAsync(serialTv);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<NoContent>> SoftDeleteAsync(int id)
        {
            var deletedSerialTv = await _repository.GetByIdAsync(c => c.Id == id);
            if (deletedSerialTv == null)
            {
                return Response<NoContent>.Fail("ilgili Dizi Bulunamadı.", 404);
            }
            if (deletedSerialTv.IsDeleted)
            {
                return Response<NoContent>.Fail("Bu Dizi Zaten Silinmiş.", 404);
            }
            deletedSerialTv.IsDeleted = !deletedSerialTv.IsDeleted;
            deletedSerialTv.IsActive = false;
            deletedSerialTv.ModifiedDate = DateTime.Now;
            await _repository.UpdateAsync(deletedSerialTv);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<SerialTvDTO>> GetByIdAsync(int id)
        {
            var serialTv = await _repository.GetByIdAsync(m => m.Id == id);
            if (serialTv == null)
            {
                return Response<SerialTvDTO>.Fail("ilgili Dizi bulunamadı.", 404);
            }
            var serialTvDto = _mapper.Map<SerialTvDTO>(serialTv);
            return Response<SerialTvDTO>.Success(serialTvDto, 200);
        }

        public async Task<Response<List<SerialTvDTO>>> GetAllAsync()
        {
            var serialTvList = await _repository.GetAllAsync();
            if (serialTvList == null)
            {
                return Response<List<SerialTvDTO>>.Fail("Hiç Dizi bulunamadı", 301);
            }
            var serialTvListDtoList = _mapper.Map<List<SerialTvDTO>>(serialTvList);
            return Response<List<SerialTvDTO>>.Success(serialTvListDtoList, 200);
        }

        public async Task<Response<List<SerialTvDTO>>> GetAllSerialTvsWithGenresAsync()
        {
            var serialTvlist = await _repository.GetAllAsync(s => s.IsActive && !s.IsDeleted,
                source => source
                    .Include(s => s.SerialTvGenres)
                    .ThenInclude(sg => sg.Genre));
            if (serialTvlist == null)
            {
                return Response<List<SerialTvDTO>>.Fail("Hiç Dizi bulunamadı", 301);
            }
            var serialTvDtoList = _mapper.Map<List<SerialTvDTO>>(serialTvlist);
            return Response<List<SerialTvDTO>>.Success(serialTvDtoList, 200);
        }

        public async Task<Response<List<SerialTvDTO>>> GetSerialTvsByGenreIdAsync(int genreId)
        {
            var serialTvList = await _repository.GetSerialTvsByGenreIdAsync(genreId);
            if (serialTvList == null)
            {
                return Response<List<SerialTvDTO>>.Fail("Bu Türde hiç ürün bulunamadı", 301);
            }
            var serialTvDtoList = _mapper.Map<List<SerialTvDTO>>(serialTvList);
            return Response<List<SerialTvDTO>>.Success(serialTvDtoList, 200);
        }

        public async Task<Response<SerialTvDTO>> GetSerialTvWithGenresAsync(int id)
        {
            var serialTv = await _repository.GetByIdAsync(s => !s.IsDeleted && s.Id == id,
                    source => source
                 .Include(s => s.SerialTvGenres)
                 .ThenInclude(sg => sg.Genre));
            if (serialTv == null)
            {
                return Response<SerialTvDTO>.Fail("İlgili Dizi bulunamadı.", 404);
            }
            var serialTvDto = _mapper.Map<SerialTvDTO>(serialTv);
            return Response<SerialTvDTO>.Success(serialTvDto, 200);
        }

        // UpdateIsHomeAsync -- Yapılcak

        public async Task<Response<int>> GetActiveSerialTvCount()
        {
            var count = await _repository.GetCountAsync(s => s.IsActive && !s.IsDeleted);
            return Response<int>.Success(count, 200);
        }


        public async Task<Response<int>> GetSerialTvCount()
        {
            var count = await _repository.GetCountAsync(s => !s.IsDeleted);
            return Response<int>.Success(count, 200);
        }


        public async Task<Response<NoContent>> UpdateIsActiveAsync(int id)
        {
            var serialTv = await _repository.GetByIdAsync(s => s.Id == id);
            if (serialTv == null)
            {
                return Response<NoContent>.Fail("İlgili Dizi bulunamadı.", 404);
            }
            serialTv.IsActive = !serialTv.IsActive;
            serialTv.ModifiedDate = DateTime.Now;
            await _repository.UpdateAsync(serialTv);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<SerialTvDTO>>> GetAllNonDeletedAsync(bool isDeleled = false)
        {
            var serialTvList = await _repository.GetAllAsync(s => s.IsDeleted == isDeleled);
            if (serialTvList == null)
            {
                return Response<List<SerialTvDTO>>.Fail("Hiç Dizi bulunamadı", 301);
            }
            var serialTvDtoList = _mapper.Map<List<SerialTvDTO>>(serialTvList);
            return Response<List<SerialTvDTO>>.Success(serialTvDtoList, 200);
        }


    }
}
