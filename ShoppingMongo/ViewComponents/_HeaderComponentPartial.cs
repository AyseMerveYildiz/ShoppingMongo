using Microsoft.AspNetCore.Mvc;

namespace ShoppingMongo.ViewComponents.Admin
{
    public class _HeaderComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
