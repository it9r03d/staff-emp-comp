using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiDemo.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class EmpController : ControllerBase {
        private readonly ILogger<EmpController> _logger;

        public EmpController(ILogger<EmpController> logger) {
            _logger = logger;
        }
        
        [HttpGet("{id}")]
        public Emp Get(string id) {
            var db = new StaffContext();
            var emp = db.Emp.Find( int.Parse(id) );
            if (emp == null) {
                emp = new Emp();
            }
            return emp;
        }

        [HttpGet]
        public IEnumerable<Emp> Get() {
            var staffContext = new StaffContext();
            return staffContext.Emp.ToArray();
        }
        
        [HttpPost]
        public ActionResult Post([FromBody] Emp value) {
            var staffContext = new StaffContext();
            var entity = new Emp {
                Name = value.Name,
                Phone = value.Phone,
                Compid = value.Compid
                //...@todo determine newOrExist fields
            };
            staffContext.Add(entity);
            staffContext.SaveChanges();
        
            OrderedDictionary keyWithValue = new OrderedDictionary();
            keyWithValue.Add("id", entity.Id);
            return Ok(keyWithValue);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Emp value) {
            var staffContext = new StaffContext();
            var emp = staffContext.Emp.Find(id);

            if (emp == null) {
                emp = new Emp();
            }

            // ...
            if (emp.Name != value.Name) {
                emp.Name = value.Name;
            }
            if (emp.Phone != value.Phone) {
                emp.Phone = value.Phone;
            }
            
            staffContext.SaveChanges();
            return new ObjectResult(emp);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {
            var staffContext = new StaffContext();
            var emp = staffContext.Emp.Find(id);

            var flag = (emp == null);
            if (flag) {
                emp = new Emp();
            } else {
                staffContext.Remove(emp);
                //await db.SaveChangesAsync();
                staffContext.SaveChanges();
            }

            return Ok(new OrderedDictionary {
                {"id", id.ToString()},
                {"result", flag ? "the employee does not found" : "the employee was deleted"}
            });
        }
    }
}
