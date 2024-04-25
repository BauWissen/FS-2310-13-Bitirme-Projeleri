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
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;

        private readonly IMapper _mapper;

        public MaterialService(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(AddMaterialViewModel addMaterialViewModel)
        {
            var material = _mapper.Map<Material>(addMaterialViewModel);
            await _materialRepository.AddAsync(material);
        }

        public async Task DeleteAsync(int id)
        {
            var material = await _materialRepository.GetByIdAsync(id);
            _materialRepository.Delete(material);
        }

        public async Task<List<MaterialViewModel>> GetAllAsync()
        {
            var materials = await _materialRepository.GetAllAsync();
            var materialViewModels = _mapper.Map<List<MaterialViewModel>> (materials);
            return materialViewModels;
        }

        public async Task<MaterialViewModel> GetByIdAsync(int id)
        {
            var material = await _materialRepository.GetByIdAsync(id);
            var materialViewModel = _mapper.Map<MaterialViewModel>(material);
            return materialViewModel;
        }

        public async Task<MaterialViewModel> UpdateAsync(UpdateMaterialViewModel updateMaterialViewModel)
        {
            var material = _mapper.Map<Material>(updateMaterialViewModel);
            _materialRepository.Update(material);
            var materialViewModel = _mapper.Map<MaterialViewModel>(material);
            return materialViewModel;
        }
    }
}