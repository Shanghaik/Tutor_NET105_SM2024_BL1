using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tutor_NET105_SM2024_BL1.Models;

namespace Tutor_NET105_SM2024_BL1.Controllers
{
    public class FoodController : Controller
    {
        public IActionResult Index()
        {
            // 4 bước cơ bản để sử dụng API
            // Bước 1: Lấy APIURL
            string apiURL = @"https://localhost:7103/api/Food/get-all-food";
            // Bước 2 là lấy response thông qua httpClient
            HttpClient client = new HttpClient();
            var response = client.GetStringAsync(apiURL).Result;
            // Bước 3: Ép kiểu nếu cần
            var data = JsonConvert.DeserializeObject<List<Food>>(response);
            // Bước 4: Dùng dữ liệu vừa lấy được
            return View(data);
        }
    }
}
