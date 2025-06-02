using Microsoft.AspNetCore.Mvc;
using ShoppingMongo.Services.CategoryServices;

namespace ShoppingMongo.ViewComponents
{
    public class _UICategoryComponentPartial: ViewComponent
    {
		private readonly ICategoryService _categoryService;

		public _UICategoryComponentPartial(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}
		public async Task<IViewComponentResult> InvokeAsync()
        {
			var values = await _categoryService.GetAllCategoryAsync();
			return View(values);
        }
    }
}
