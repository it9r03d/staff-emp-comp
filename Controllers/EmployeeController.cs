//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//
//namespace WebApiDemo.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class EmployeeController : ControllerBase
//    {
//        private static readonly string[] Summaries = new[]
//        {
//            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//        };
//
//        private readonly ILogger<EmployeeController> _logger;
//
//        public EmployeeController(ILogger<EmployeeController> logger)
//        {
//            _logger = logger;
//        }
//        
//        [HttpGet("{id}")]
////        public ActionResult<string> Get(string id)
//        //public Employee Get(string id)
//        public IActionResult Get(string id)
//        {
//            //if ((int.Parse(id) % 2) != 0) {
//                //return StatusCode(200, null);
//                //return Problem("detail", "instance", 404, "title", "type");
//                //new string[] { "isNotFound", "Get", "id:"+ id, (int.Parse(id) % 2) != 0 ? "+": "-" });
//                //return NotFound(new string[] { "isNotFound", "Get", "id:"+ id, (int.Parse(id) % 2) != 0 ? "+": "-" });
//            //}
//            //return Ok(new string[] { "is:Ok", "Get", "id:"+ id, (int.Parse(id) % 2) != 0 ? "+": "-" });
//            var employee =  new Employee {
//                Id = int.Parse(id),
//                Name = "isValueForName",
//                SurName = "isValueForSurName",
//                Phone = "+79876543210",
//                CompanyId = 1,
//                PassportNumber = "n44",
//                PassportType = "T44",
//            };
//            var empty = new Employee();
//            //return ((int.Parse(id) % 2) != 0) ? empty : employee;
//            return new ObjectResult(((int.Parse(id) % 2) != 0) ? empty : employee);
//        }
//
//        [HttpGet]
//        public IEnumerable<Employee> Get() {
////        public Employee[] Get() {
//            var rng = new Random();
//            return Enumerable.Range(1, 3).Select(index => new Employee {
//                    Id = rng.Next(1, 55),
//                    Name = "isValueForName",
//                    SurName = "isValueForSurName",
//                    Phone = "+79876543210",
//                    CompanyId = 1,
//                    PassportNumber = "n44",
//                    PassportType = "T44",
//                }).ToArray();
//        }
//        
//        // POST api/employee
//        [HttpPost]
////        public ActionResult<string> Post([FromBody] Employee value) {
//        public ActionResult Post([FromBody] Employee value) {
////            return Ok(new string[] { "is", "Post", "ok"});
//            return new ObjectResult(value);
//        }
//
//        // PUT api/employee/5
//        [HttpPut("{id}")]
////        public ActionResult<string> Put(int id, [FromBody] string value)
//        public ActionResult Put(int id, [FromBody] Employee value)
//        {
////            return Ok(new string[] { "is", "Put", "ok", id.ToString(), value});
//            return Ok(new string[] { "is", "Put", "ok", id.ToString()});
//        }
//
//        // DELETE api/employee/5
//        [HttpDelete("{id}")]
//        public ActionResult<string> Delete(int id) {
//            return Ok(new string[] { "is", "Delete", "ok", id.ToString()});
//        }
//
//        
//    }
//}
