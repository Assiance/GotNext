using System.Web.Mvc;
using GotNext.Web.Infrastructure.Controllers;

namespace GotNext.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }
    }
}
