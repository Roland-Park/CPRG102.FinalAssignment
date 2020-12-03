using CPRG102.Final.Roland.UI.HRData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG102.Final.Roland.UI.Controllers
{
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
