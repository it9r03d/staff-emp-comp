using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApiDemo.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class StaffController : ControllerBase {
        [HttpGet("{idCompany}")]
        public ActionResult Get(string idCompany) {
            List<Emp> listEmp = (new StaffContext()).Emp
                .Include(c => c.Comp)
                .Include(p => p.Passport)
                .Where(e => e.Compid == int.Parse(idCompany))
                .ToList();
             
            return listEmp.Count > 0 ?
                new ObjectResult(Ok(listEmp)) :
                new ObjectResult(NotFound(listEmp));
        }
    }
}
