using Microsoft.AspNetCore.Mvc;

namespace ShoppingMongo.ViewComponents.Admin
{
    public class _ScriptComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
