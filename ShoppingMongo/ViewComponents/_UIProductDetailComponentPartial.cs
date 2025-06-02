using Microsoft.AspNetCore.Mvc;
using ShoppingMongo.Services.ProductServices;

namespace ShoppingMongo.ViewComponents
{
    public class _UIProductDetailComponentPartial: ViewComponent
    {
		private readonly IProductService _productService;

		public _UIProductDetailComponentPartial(IProductService productService)
		{
			_productService = productService;
		}
		public async Task<IViewComponentResult> InvokeAsync(string id)
        {
			var values = await _productService.GetProductByIdAsync(id);
			return View(values);
        }
    }
}
