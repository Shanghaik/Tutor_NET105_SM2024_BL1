using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        [HttpGet("get-leopad")]
        public ActionResult<string> LuckyDraw(int betnumber, int betmoney)
        {
            Random r = new Random();
            int result = r.Next(100000, 999999);
            if ((result - betnumber) % 100 == 0)
            {
                return Ok($"Bạn rất may mắn, đã trúng {betmoney * 75}");
            }
            else return BadRequest("Bạn đừng đặt cược bản thân mình vào những trò may rủi, kết quả là " + result);
        }
        [HttpGet("solve-equation")]
        public ActionResult<string> EquationSolve(int a, int b)
        {
            if (a == 0)
            {
                if (b == 0) return Ok("There is always a solution");
                else return Ok("No solution");
            }
            else
            {
                if (b == 0) return Ok("There is only solution x = 0");
                else return Ok($"The is only solution x = {b * -1.0 / a}");
            }
        }
    }
}
