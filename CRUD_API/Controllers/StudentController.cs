using CRUD_API.IServices;
using CRUD_API.Models;
using CRUD_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentServices _services = new StudentServices();
        [HttpGet("get-all-student")]
        public ActionResult GetAll()
        {
            return Ok(_services.GetAll());
        }
        [HttpGet("get-student-by-id")]
        public ActionResult Get(string id)
        {
            return Ok(_services.GetById(id));
        }
        [HttpPost("create-student")]
        public ActionResult Create(Student student) { 
            if(_services.CreateStudent(student))
            {
                return Ok();
            }else return BadRequest();
        }
        [HttpPost("update-student")]
        public ActionResult Update(Student student)
        {
            if (_services.UpdateStudent(student))
            {
                return Ok();
            }
            else return BadRequest();
        }
        [HttpDelete("delete-student")]
        public ActionResult Delete(string id)
        {
            if (_services.DeleteStudent(id))
            {
                return Ok();
            }
            else return BadRequest();
        }

    }
}
