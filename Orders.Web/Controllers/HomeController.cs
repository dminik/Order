namespace Orders.Web.Controllers
{
    using System.Globalization;
    using System.Threading;
    using System.Web;
    using System.Web.Mvc;

    public class HomeController : BaseController
    {                
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            if (requestContext.HttpContext.Request.Url != null)
            {
                HostName = requestContext.HttpContext.Request.Url.Authority;
            }

            var routeData = requestContext.RouteData;
            var routeCulture = routeData != null ? routeData.Values["lang"].ToString() : null;
            var languageCookie = requestContext.HttpContext.Request.Cookies["lang"];
            var userLanguages = requestContext.HttpContext.Request.UserLanguages;

	        var lang = routeCulture ?? (languageCookie != null ? languageCookie.Value : userLanguages != null ? userLanguages[0] : "ru");
			ViewBag.Lang = lang.ToLower();
			var cultureInfo = new CultureInfo(lang);

            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
	        
            base.Initialize(requestContext);
        }

        public ActionResult ChangeCulture(string lang)
        {
            var langCookie = new HttpCookie("lang", lang) { HttpOnly = true };
            Response.AppendCookie(langCookie);
            return RedirectToAction("Index2", "Home", new { lang = lang });
        }

        public ActionResult Index(string returnUrl)
        {           
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public ActionResult Index2(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
    }
}