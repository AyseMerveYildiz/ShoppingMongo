using Microsoft.AspNetCore.Mvc;
using ShoppingMongo.Services.SliderServices;

namespace ShoppingMongo.ViewComponents
{
    public class _UISliderComponentPartial: ViewComponent
    {
		private readonly ISliderService _sliderService;
		public _UISliderComponentPartial(ISliderService sliderService)
		{
			_sliderService = sliderService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _sliderService.GetAllSliderAsync();
			return View(values);
		}
    }
}
