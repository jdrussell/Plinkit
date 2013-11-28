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
            ViewBag.Message = "Your one stop shop for Daily Programming Links.";
            return View("Index", new DailyLinksViewModel(new SqlDailyLinksRepository(),
                                                         GetRequestedLinksDate(date),
                                                         GetRequestedLinksCategory(category)));
        }

        private string GetRequestedLinksCategory(string category)
        {
            var linkCategory = (string.IsNullOrEmpty(category)) ? "webDevelopment" : category;
            return linkCategory.Replace("-", "");
        }

        private DateTime GetRequestedLinksDate(string date)
        {
            DateTime linksDate;
            DateTime.TryParse(date, CultureInfo.GetCultureInfo("en-GB"), DateTimeStyles.None, out linksDate);
            return (linksDate == DateTime.MinValue)
                       ? DateTime.Now.Date
                       : linksDate;
        }

        public ActionResult About()
        {                     
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Please contact me with any feedback or suggestions you have on the site.";
            return View();
        }
    }
}
