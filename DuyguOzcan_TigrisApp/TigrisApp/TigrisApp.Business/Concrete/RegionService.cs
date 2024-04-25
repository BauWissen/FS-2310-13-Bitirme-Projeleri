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
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionService(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(AddRegionViewModel addRegionViewModel)
        {
        //    var region = new Region
        //    {
        //     Name=addRegionViewModel.Name,
        //     CreatedDate=DateTime.Now,
        //     ModifiedDate=DateTime.Now
        //    };
                var region = _mapper.Map<Region>(addRegionViewModel);
           await _regionRepository.AddAsync(region);
        }

        public async Task DeleteAsync(int id)
        {
            var region= await _regionRepository.GetByIdAsync(id);
             _regionRepository.Delete(region);
        }

        public async Task<List<RegionViewModel>> GetAllAsync()
        {
            var regions = await _regionRepository.GetAllAsync();
            // List<RegionViewModel> regionViewModels = regions.Select(x=>new RegionViewModel
            // {
            //     Id= x.Id,
            //     CreatedDate= x.CreatedDate,
            //     ModifiedDate= x.ModifiedDate,
            //     Name=x.Name
            // }).ToList();
            var regionViewModels = _mapper.Map<List<RegionViewModel>>(regions);
            return regionViewModels;
        }

        public async Task<RegionViewModel> GetByIdAsync(int id)
        {
            var region= await _regionRepository.GetByIdAsync(id);
            var regionViewModel = _mapper.Map<RegionViewModel>(region);
            return regionViewModel;
        }

        public async Task<RegionViewModel> UpdateAsync(UpdateRegionViewModel updateRegionViewModel)
        {
            var region = _mapper.Map<Region>(updateRegionViewModel);
            _regionRepository.Update(region);
            var regionViewModel = _mapper.Map<RegionViewModel>(region);
            return regionViewModel;
        }
    }
}