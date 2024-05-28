using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        [HttpGet("get-all-food")]
        public ActionResult<string> GetAllFood()
        {
            List<Food> foods = new List<Food>()
            {
                new Food() {Name = "Thịt bòa", Description = "Bò Wagyu A1"},
                new Food() {Name = "Thịt gà", Description = "Gà tần nước mắm"},
                new Food() {Name = "Rau sạch", Description = "Rau sạch non mơn mởn ăn 1 lần là nhớ"}
            };
            return Ok(foods);
        }
    }
    public class Food
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
