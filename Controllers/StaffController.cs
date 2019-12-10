using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiDemo.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class StaffController : ControllerBase {
        private static readonly string[] Names = new[] {
            "Ivan", "Vanya", "Jone", "Gorge", "Sedan", "Semen", "Dina", "Tom", "Leonid", "Logan"
            //"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<StaffController> _logger;

        public StaffController(ILogger<StaffController> logger) {
            _logger = logger;
        }
        
        [HttpGet("{idCompany}")]
//        public ActionResult<string> Get(string id)
//        public Employee Get(string idCompany)
//        public ActionResult<Employee> Get(string idCompany)
        public IEnumerable<Employee> Get(string idCompany)
        {
            //return Ok(new string[] { "is:Ok", "Get", "id:"+ id, (int.Parse(id) % 2) != 0 ? "+": "-" });
//            var employee = new Employee {
//                Id = int.Parse(idCompany),
//                Name = "isValueForName",
//                SurName = "isValueForSurName",
//                Phone = "+79876543210",
//                CompanyId = 1,
//                PassportNumber = "n44",
//                PassportType = "T44",
//            };
//            var empty = new Employee();
//            //return (((int.Parse(idCompany) % 2) != 0) ? empty : employee);
//            return Ok(new Employee[] {empty, employee});
            var rng = new Random();
            return Enumerable.Range(1, 3).Select(index => new Employee {
                Id = rng.Next(1, 55),
                Name = Names[rng.Next(Names.Length)],
                SurName = "SurName",
                Phone = "+7987" + rng.Next(1111111, 9999999),
                CompanyId = int.Parse(idCompany),
                PassportNumber = rng.Next(10000000, 99999999).ToString(),
                PassportType = rng.Next(1000, 9999).ToString(),
            }).ToArray();
        }
    }
}
