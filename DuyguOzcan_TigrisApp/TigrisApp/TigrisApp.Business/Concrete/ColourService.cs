using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TigrisApp.Business.Abstract;
using TigrisApp.Data.Abstract;
using TigrisApp.Entity.Concrete;
using TigrisApp.Shared.ViewModels;

namespace TigrisApp.Business.Concrete
{
    public class ColourService : IColourService
    {
        private readonly IColourRepository _colourRepository;
        private readonly IMapper _mapper;

        public ColourService(IColourRepository colourRepository, IMapper mapper)
        {
            _colourRepository = colourRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(AddColourViewModel addColourViewModel)
        {
            var colour= _mapper.Map<Colour>(addColourViewModel);
            await _colourRepository.AddAsync(colour);
        }

        public async Task DeleteAsync(int id)
        {
            var colour = await _colourRepository.GetByIdAsync(id);
            _colourRepository.Delete(colour);
        }

        public async Task<List<ColourViewModel>> GetAllAsync()
        {
            var colours= await _colourRepository.GetAllAsync();
            var colourViewModels = _mapper.Map<List<ColourViewModel>>(colours);
            return colourViewModels;
        }

        public async Task<ColourViewModel> GetByIdAsync(int id)
        {
            var colour = await _colourRepository.GetByIdAsync(id);
            var colourViewModel = _mapper.Map<ColourViewModel>(colour);
            return colourViewModel;
        }

        public async Task<ColourViewModel> UpdateAsync(UpdateColourViewModel updateColourViewModel)
        {
            var colour= _mapper.Map<Colour>(updateColourViewModel);
            _colourRepository.Update(colour);
            var colourViewModel= _mapper.Map<ColourViewModel>(colour);
            return colourViewModel;
        }
    }
}