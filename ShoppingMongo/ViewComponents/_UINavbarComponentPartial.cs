using Microsoft.AspNetCore.Mvc;

namespace ShoppingMongo.ViewComponents
{
    public class _UINavbarComponentPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
