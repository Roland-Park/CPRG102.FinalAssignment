using CPRG102.Final.Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG102.Final.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        public EmployeeController(HRContext context)
        {
            Context = context;
        }

        public HRContext Context { get; }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return Context.Employees.ToList();
        }

        [HttpGet("{employeeNumber}")]
        public IEnumerable<Employee> Get(string employeeNumber)
        {
            return Context.Employees.Where(x => x.EmployeeNumber == employeeNumber).ToList();
        }

        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            Context.Employees.Add(employee);
            Context.SaveChanges();

            return CreatedAtAction("Post", employee);
        }
    }
}
