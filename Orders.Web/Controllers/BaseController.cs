namespace Orders.Web.Controllers
{
    using System.Web.Mvc;

    public abstract class BaseController : Controller
    {
        public static string HostName = string.Empty;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            
            if (requestContext.HttpContext.Request.Url != null)
            {
                HostName = requestContext.HttpContext.Request.Url.Authority;
            }
            
            base.Initialize(requestContext);
        }
    }
}