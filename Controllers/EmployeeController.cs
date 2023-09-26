using Microsoft.AspNetCore.Mvc;
using NetCoreWebAPIUnitTest_xUnit.Model;
using NetCoreWebAPIUnitTest_xUnit.Services;

namespace NetCoreWebAPIUnitTest_xUnit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var emps = _service.GetAll();
            return Ok(emps);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var emp = _service.GetById(id);
            if (emp != null)
            {
                return Ok(emp);
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult Post([FromBody] Employee emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }    
            var newEmp = _service.Add(emp);
            return CreatedAtAction("Get", newEmp);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(_service.Delete(id))
            {
                return Ok("The Employee is deleted.");
            }
            return NotFound("The Employee not Found");
        }
    }
}
