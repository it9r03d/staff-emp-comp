using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDemo.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class EmpController : ControllerBase {
        private StaffContext _dbContext;

        public EmpController() {
            _dbContext = new StaffContext();
        }

        //[HttpGet("{id}")]
        //public ActionResult Get(string id) {
        //    object emp = _dbContext.Emp.Find( int.Parse(id) );
        //    return emp == null ? new ObjectResult(NotFound( int.Parse(id))) : new ObjectResult(Ok(emp));
        //}

        //[HttpGet]
        //public IEnumerable<Emp> Get() {
        //    return _dbContext.Emp.ToArray();
        //}

        [HttpPost]
        public ActionResult Post([FromBody] Emp value) {
            if (value.Compid == 0) {
                OrderedDictionary keyWValue = new OrderedDictionary();
                keyWValue.Add("id", null);
                keyWValue.Add("result", "not exist value for `Compid` field");
                return new ObjectResult(BadRequest(keyWValue));
            }

            if (value.Passportid == 0) {
                OrderedDictionary keyWValue = new OrderedDictionary();
                keyWValue.Add("id", null);
                keyWValue.Add("result", "not exist value for `Passportid` field");
                return new ObjectResult(BadRequest(keyWValue));
            }

            Emp entity = new Emp {
                Name = value.Name,
                SurName = value.SurName,
                Phone = value.Phone,
                Compid = value.Compid,
                Passportid = value.Passportid
            };
            _dbContext.Add(entity);
            _dbContext.SaveChanges();

            return new ObjectResult(Ok(new OrderedDictionary {{"id", entity.Id}}));
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Emp value) {
            Emp emp = _dbContext.Emp.Find(int.Parse(id));

            if (emp == null) {
                return new ObjectResult(NotFound(int.Parse(id)));
            }

            if (emp.Name != value.Name) {
                emp.Name = value.Name;
            }
            if (emp.SurName != value.SurName) {
                emp.SurName = value.SurName;
            }
            if (emp.Phone != value.Phone) {
                emp.Phone = value.Phone;
            }
            
            _dbContext.SaveChanges();
            return new ObjectResult(Ok(emp));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id) {
            Emp emp = _dbContext.Emp.Find(int.Parse(id));

            if (emp == null) {
                return new ObjectResult(NotFound(int.Parse(id)));
            }
            _dbContext.Remove(emp);
            _dbContext.SaveChanges();

            return new ObjectResult(Ok(new OrderedDictionary {
                {"id", id.ToString()},
                {"result", "the employee remove done"}
            }));
        }
    }
}
