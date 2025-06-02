using Microsoft.AspNetCore.Mvc;

namespace ShoppingMongo.ViewComponents.Admin
{
    public class _SidebarComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
