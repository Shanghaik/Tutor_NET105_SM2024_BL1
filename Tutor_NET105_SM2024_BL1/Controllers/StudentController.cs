using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tutor_NET105_SM2024_BL1.Models;

namespace Tutor_NET105_SM2024_BL1.Controllers
{
    public class StudentController : Controller
    {
        HttpClient client;
        public StudentController()
        {
            client = new HttpClient();
        }
        public IActionResult GetAll()
        {
            string requestURL = "https://localhost:7243/api/Student/get-all-student";
            var response = client.GetStringAsync(requestURL).Result;
            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(response);
            return View(students);
        }
        [HttpGet]
        public IActionResult Create() {
            Student student = new Student()
            {
                Name = "Dữ liệu mẫu",
                Major = "UDPM",
                PhoneNumber = "0966123456"
            };
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            string requestURL = "https://localhost:7243/api/Student/create-student";
            var response = await client.PostAsJsonAsync(requestURL, student);
            Console.WriteLine(response);
            return RedirectToAction("GetAll");
        }
        [HttpGet]
        public IActionResult Update(string id)
        {
            string requestURL = $"https://localhost:7243/api/Student/get-student-by-id?id={id}";
            var response = client.GetStringAsync(requestURL).Result;
            Student student = JsonConvert.DeserializeObject<Student>(response);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Student student)
        {
            string requestURL = "https://localhost:7243/api/Student/update-student";
            var response = await client.PostAsJsonAsync(requestURL, student);
            Console.WriteLine(response);
            return RedirectToAction("GetAll");
        }
        // Do razor view chỉ cho phép get và post nên dùng put là tịt =)))
    }
}
