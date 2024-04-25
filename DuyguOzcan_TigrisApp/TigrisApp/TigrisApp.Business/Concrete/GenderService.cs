using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.VisualBasic;
using TigrisApp.Business.Abstract;
using TigrisApp.Data.Abstract;
using TigrisApp.Shared.ViewModels;

namespace TigrisApp.Business.Concrete
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IMapper _mapper;

        public GenderService(IGenderRepository genderRepository, IMapper mapper)
        {
            _genderRepository = genderRepository;
            _mapper = mapper;
        }

        public Task AddAsync(AddGenderViewModel addGenderViewModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GenderViewModel>> GetAllAsync()
        {
            var genders = await _genderRepository.GetAllAsync();
            var genderViewModels = _mapper.Map<List<GenderViewModel>>(genders);
            return genderViewModels;
        }

        public Task<GenderViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GenderViewModel> UpdateAsync(UpdateGenderViewModel updateGenderViewModel)
        {
            throw new NotImplementedException();
        }
    }
}