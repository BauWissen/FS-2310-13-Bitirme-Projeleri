﻿using RhythmicRealm.Shared.Response;
using RhythmicRealm.Shared.ViewModels.SubCategoryViewModels;

namespace RhythmicRealm.Service.Abstract
{
	public interface ISubCategoryService
	{
        Task<Response<List<SubCategoryViewModel>>> GetAllSubCategoriesAsync(); 
        Task<Response<SubCategoryViewModel>> GetSubCategoryWithMainCategory(int id);
        Task<Response<List<InSubCategoryViewModel>>> GetSubCategoriesByMainCategoryId(int mainCategoryId); 
        Task<Response<SubCategoryViewModel>> GetSubCategoryByIdAsync(int id);
        Task<Response<SubCategoryViewModel>> GetSubCategoryWithProductsAsync(int subCategoryId);
        Task<Response<List<SubCategoryViewModel>>> GetSubCategoriesByIsActiveAsync(bool isActive = true);
        Task<Response<List<SubCategoryViewModel>>> GetSubCategoriesByIsDeleteAsync(bool isDeleted = false);
        Task<Response<SubCategoryViewModel>> CreateSubCategoryAsync(AddSubCategoryViewModel addSubCategoryViewModel);
		Task<Response<SubCategoryViewModel>> UpdateSubCategoryAsync(EditSubCategoryViewModel editSubCategoryViewModel);
		Task<Response<NoContent>> SoftDeleteSubCategoryAsync(int id);
		Task<Response<NoContent>> HardDeleteSubCategoryAsync(int id);
		Task<bool> UpdateIsActiveAsync(int id); 
	}
}
