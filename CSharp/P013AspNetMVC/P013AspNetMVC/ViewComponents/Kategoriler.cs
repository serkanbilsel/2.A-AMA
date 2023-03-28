using Microsoft.AspNetCore.Mvc;

namespace P013AspNetMVC.ViewComponents
{
    public class Kategoriler : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }


    }
}
