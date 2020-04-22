using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AllCoreInOne.Models;
using AllCoreInOne.Services.CurrentUser;

namespace AllCoreInOne.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> _logger { get; }
        private ICurrentUser CurrentUser { get; }

        public HomeController(ILogger<HomeController> logger, ICurrentUser currentUser)
        {
            _logger = logger;
            CurrentUser = currentUser;
        }

        public IActionResult Index()
        {
            _logger.LogInformation($"Current User id {CurrentUser.Id} and name {CurrentUser.FullName}");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
