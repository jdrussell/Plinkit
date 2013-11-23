using System;
using System.Web.Mvc;
using Plinkit.Domain.Repositories;
using Plinkit.UI.ViewModels;

namespace Plinkit.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Your one stop shop for Programmer Links.";                  
            return View(new DailyLinksViewModel(new SqlDailyLinksRepository(),                                                
                                                DateTime.Now.Date));
        }

        public ActionResult About()
        {
            ViewBag.Message = "pLinkIt.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Please contact me with any feedback or suggestions you have on the site.";
            return View();
        }
    }
}
