using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace Tutor_NET105_SM2024_BL1.Controllers
{
    public class CalculatorController : Controller
    {
        HttpClient client = new HttpClient();
        public IActionResult Calculators()
        {
            if (HttpContext.Session.GetString("prime") != null)
                ViewData["prime"] = HttpContext.Session.GetString("prime");
            else
                ViewData["prime"] = "Hãy nhập một dãy số để check";
            if (HttpContext.Session.GetString("interest") != null)
                ViewData["interest"] = HttpContext.Session.GetString("interest");
            else
                ViewData["interest"] = "Hãy nhập dữ liệu";
            return View();
        }
        public ActionResult CalculateInterest(int month, double percent, long money)
        {
            // lấy requestURL 
            string requestURL = @$"https://localhost:7103/calculator/double-interest?month={month}&percent={percent}&money={money}";
            // Lấy response  
            string response = client.GetStringAsync(requestURL).Result;
            HttpContext.Session.SetString("interest", response);
            return RedirectToAction("Calculators");
        }
        public ActionResult CheckPrime(string prime)
        {
            // lấy requestURL 
            string requestURL = @$"https://localhost:7103/calculator/check-prime-number?listNumber={prime}";
            // Lấy response
            string response = client.GetStringAsync(requestURL).Result;
            HttpContext.Session.SetString("prime", response);
            return RedirectToAction("Calculators");
        }

    }
}
