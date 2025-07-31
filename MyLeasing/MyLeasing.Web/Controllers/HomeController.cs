using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyLeasing.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //  Action para About
        public IActionResult About()
        {
            ViewData["Message"] = "Application information.";
            return View();
        }

        //  Action para Contact
        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact Page.";
            return View();
        }

        // Action para Owners
        public IActionResult Owners()
        {
            ViewData["Message"] = "Owners page.";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
