using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("double-interest")]
        public ActionResult GetInterest(int month, double percent, long money)
        {
            long moneyAfter = (long)Math.Round(money * Math.Pow((1 + percent / 100), month), 0);
            string result = $"Tiền con báo về khi nợ {money} sau {month} tháng là {moneyAfter - money}";
            return Ok(result);
        }
        [HttpGet("check-prime-number")]
        public ActionResult CheckPrimeNumber(string listNumber) 
        {
            string[] numbers = listNumber.Split(" "); // Hàm split để cắt chuỗi thep dấu cách
            foreach(string number in numbers) // Check xem toàn bộ dãy có phải số hay không
            {
                int output; // Không cần khỏi tạo
                bool check = int.TryParse(number, out output); // Dùng tryparse để check
                if(!check) return BadRequest("Dữ liệu đầu vào không đúng, vui lòng kiểm tra lại");
            }
            string results = "";
            foreach (string number in numbers)
            {
                int checkNumber = Convert.ToInt32(number);
                if (checkNumber < 2) continue; // Nhỏ hơn 2 bỏ qua
                if (checkNumber == 2) { results += (checkNumber + " "); continue; }
                if (checkNumber > 2 && checkNumber % 2 == 0) continue;
                int count = 0;
                for (int i = 3; i <= Math.Sqrt(checkNumber); i+=2)
                {
                    if(checkNumber%i==0)
                    {
                        count++;
                        break;
                    }
                }
                if(count == 0) results += (checkNumber + " ");
            }
            return Ok(results); 
        }
    }
}
