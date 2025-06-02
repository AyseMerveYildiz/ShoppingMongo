using ShoppingMongo.Dtos.CategoryDtos;
using ShoppingMongo.Dtos.CategoryDtos;

namespace ShoppingMongo.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);
        Task<GetCategoryDto> GetCategoryByIdAsync(string id);
    }
}
