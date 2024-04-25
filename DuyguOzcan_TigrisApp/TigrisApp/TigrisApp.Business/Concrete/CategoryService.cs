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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(AddCategoryViewModel addCategoryViewModel)
        {
            var category = _mapper.Map<Category>(addCategoryViewModel);
            await _categoryRepository.AddAsync(category);

        }

        public async Task DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            _categoryRepository.Delete(category);
        }

        public async Task<List<CategoryViewModel>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoriesViewModels = _mapper.Map<List<CategoryViewModel>>(categories);
            return categoriesViewModels;
        }

        public async Task<CategoryViewModel> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            var categoryViewModel = _mapper.Map<CategoryViewModel>(category);
            return categoryViewModel;
        }

        public async Task<CategoryViewModel> UpdateAsync(UpdateCategoryViewModel updateCategoryViewModel)
        {
            var category= _mapper.Map<Category>(updateCategoryViewModel);
            _categoryRepository.Update(category);
            var categoriesViewModel= _mapper.Map<CategoryViewModel>(category);
            return categoriesViewModel;
        }
    }
}