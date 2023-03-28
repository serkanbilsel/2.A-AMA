using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace P013AspNetMVC.Filters
{
    public class UserControl : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var userGuid = context.HttpContext.Session.GetString("UserGuid"); // uygulanın çalıştığı ekrandaki UserGuid isimli session ı yakalıyor. O ekrandaki kullanıcıyı yani
            var userCookie = context.HttpContext.Request.Cookies["userguid"]; // cookie yi yakala <--- ufak olan user guid cookie deki verdiğimiz user guid
            if (userGuid == null)
            {
                context.Result = new RedirectResult("/MVC11Session?msg=AccessDenied");
            }
            base.OnActionExecuted(context);
        }
    }
}
