using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreVisitcount.Managers;

namespace AspnetCoreVisitcount.Controllers
{
    public class HomeController : Controller
    {
        CachManager _cache = null;

        public HomeController()
        {
            _cache = new CachManager();
        }

        void SetPageVisitCounterViewDate(string page)
        {
            var pageVisitCount = _cache.GetPageVisitCounter(page);
            ViewData["PageVisitCount"] = pageVisitCount > 0 ? pageVisitCount.ToString() : "Please bind Redis service.";
        }

        public IActionResult Index()
        {
            SetPageVisitCounterViewDate("Index");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            SetPageVisitCounterViewDate("About");

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            SetPageVisitCounterViewDate("Contact");

            return View();
        }

        public IActionResult Error()
        {
            var pageVisitCount = _cache.GetPageVisitCounter("Error");
            ViewData["PageVisitCount"] = pageVisitCount;
            return View();
        }
    }
}
