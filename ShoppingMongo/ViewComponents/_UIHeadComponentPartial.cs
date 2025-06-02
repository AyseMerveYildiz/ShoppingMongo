using Microsoft.AspNetCore.Mvc;

namespace ShoppingMongo.ViewComponents
{
    public class _UIHeadComponentPartial : ViewComponent
    {
        public  IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
