using Microsoft.AspNetCore.Mvc;
using ShoppingMongo.Services.ProductServices;

namespace ShoppingMongo.ViewComponents
{
    public class _UIProductComponentPartial:ViewComponent
    {
		private readonly IProductService _productService;
		public _UIProductComponentPartial(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
			var values = await _productService.GetAllProductAsync();
			return View(values);
        }
    }
   
}
