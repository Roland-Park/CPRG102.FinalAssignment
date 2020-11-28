using CPRG102.Final.Roland.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG102.Final.Roland.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }


        public async Task<IActionResult> Index()
        {
            var employees = await employeeService.GetEmployees();
            return View(employees);
        }
    }
}
