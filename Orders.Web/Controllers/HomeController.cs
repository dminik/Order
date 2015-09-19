namespace Orders.Web.Controllers
{
    using System.Globalization;
    using System.Threading;
    using System.Web.Mvc;

    public class HomeController : BaseController
    {
        public string CurrentLangCode { get; protected set; }

        //public Language CurrentLang { get; protected set; }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            if (requestContext.HttpContext.Request.Url != null)
            {
                HostName = requestContext.HttpContext.Request.Url.Authority;
            }

            if (requestContext.RouteData.Values["lang"] != null && requestContext.RouteData.Values["lang"] as string != "null")
            {
                CurrentLangCode = requestContext.RouteData.Values["lang"] as string;
                //CurrentLang = Repository.Languages.FirstOrDefault(p => p.Code == CurrentLangCode);

                var ci = new CultureInfo(CurrentLangCode);
                Thread.CurrentThread.CurrentUICulture = ci;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
            }
            base.Initialize(requestContext);
        }

        public ActionResult Index(string returnUrl)
        {
            //Orders.Resources
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