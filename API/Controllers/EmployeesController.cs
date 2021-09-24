using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Shared.ViewModels;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeVM addEmployeeVM)
        {
            var result = _employeeService.AddEmployee(addEmployeeVM);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost]
        public IActionResult UpdateEmployee(EditEmployeeVM editEmployeeVM)
        {
            var result = _employeeService.UpdateEmployee(editEmployeeVM);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var result = _employeeService.GetAllEmployees();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);

        }

        [HttpGet]
        public IActionResult GetEmployeeById(int Id)
        {
            var result = _employeeService.GetEmployeeById(Id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete]
        public IActionResult DeleteEmployee(int Id)
        {
            var result = _employeeService.DeleteEmployee(Id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }


    }
}
