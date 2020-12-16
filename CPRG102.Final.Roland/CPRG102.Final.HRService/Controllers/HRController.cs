using CPRG102.Final.HRService.HRData;
using CPRG102.Final.Roland.Domain;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CPRG102.Final.HRService.Controllers
{
    [EnableCors("FunnestPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class HRController : ControllerBase
    {
        private readonly HRContext context;
        public HRController(HRContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return context.Employees.ToList();
        }

        [HttpGet("{employeeNumber}")]
        public IEnumerable<Employee> Get(string employeeNumber)
        {
            return context.Employees.Where(x => x.EmployeeNumber == employeeNumber).ToList();
        }

        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();

            return CreatedAtAction("Post", employee);
        }
    }
}
