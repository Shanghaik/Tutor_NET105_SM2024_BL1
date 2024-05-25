using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tutor_NET105_SM2024_BL1.Models;

namespace Tutor_NET105_SM2024_BL1.Controllers
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
            // Đọc data từ Session
            var data = HttpContext.Session.GetString("account");
            if (data == null || data.ToString().Length == 0)
            {
                ViewData["account"] = "Chưa đăng nhập";
            }
            else ViewData["account"] = "Đã đăng nhập";
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