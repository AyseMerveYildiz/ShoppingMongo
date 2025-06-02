using Microsoft.AspNetCore.Mvc;

namespace ShoppingMongo.ViewComponents
{
    public class _UIScriptComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
