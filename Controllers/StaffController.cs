using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WebApiDemo.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class StaffController : ControllerBase {
        private readonly ILogger<StaffController> _logger;

        public StaffController(ILogger<StaffController> logger) {
            _logger = logger;
        }
        
        [HttpGet("{idCompany}")]
        public IEnumerable<Emp> Get(string idCompany) {
            return new StaffContext().Emps
                .Include(c => c.Comp)
                .Include(p => p.Passport)
                .Where(e => e.Compid == int.Parse(idCompany))
                .ToList();
        }
    }
}
