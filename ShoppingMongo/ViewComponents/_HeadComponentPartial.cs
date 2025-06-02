using Microsoft.AspNetCore.Mvc;

namespace ShoppingMongo.ViewComponents.Admin
{
    public class _HeadComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
