using Microsoft.AspNetCore.Mvc;

namespace ShoppingMongo.ViewComponents.Admin
{
    public class _NavbarComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
