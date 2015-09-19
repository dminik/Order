namespace Orders.Web.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
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