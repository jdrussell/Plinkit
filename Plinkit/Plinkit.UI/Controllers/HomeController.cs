using System;
using System.Globalization;
using System.Web.Mvc;
using Plinkit.Domain.Repositories;
using Plinkit.UI.ViewModels;

namespace Plinkit.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Your one stop shop for Daily Programming Links.";                  
            return View(new DailyLinksViewModel(new SqlDailyLinksRepository(),                                                
                                                DateTime.Now.Date));
        }

        public ActionResult Links(string date, string category)
        {
            var linkDate = new DateTime();
            var linkCategory = (category == "") ? "webDevelopment" : category;
            DateTime.TryParse(date, CultureInfo.GetCultureInfo("en-GB"), DateTimeStyles.None, out linkDate);
            ViewBag.Message = "Your one stop shop for Daily Programming Links.";
            return View("Index", new DailyLinksViewModel(new SqlDailyLinksRepository(),
                                                         linkDate,
                                                         linkCategory.Replace("-", "")));
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
