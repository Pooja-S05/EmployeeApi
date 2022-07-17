using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Models;
using Employee.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmplyeeController : ControllerBase
    {
        public readonly IEmployeeService _employeeService;
        public EmplyeeController(IEmployeeService employeeService)
        {
            _employeeService=employeeService;
        }
        [HttpPost]
        public async Task<ActionResult> CreateEmployee(Employees employee)
        {
            return _employeeService.CreateEmployee(employee)? await Task.FromResult(Ok("Created Successfully")):BadRequest("Error Occured while creating Employee");
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteEmployee(int EmployeeId)
        {
            return _employeeService.DeleteEmployee(EmployeeId)? await Task.FromResult(Ok("Successfully Deleted")):BadRequest("Error Occured While Deleting the record");
        }
        [HttpGet]
        public async Task<ActionResult> GetEmployee(int EmployeeId)
        {
            var Employee=_employeeService.GetEmployee(EmployeeId);
            return await Task.FromResult(Ok(Employee));
        }
        [HttpPatch]
        public async Task<ActionResult> UpdateEmployee(Employees employee)
        {
            var Employee=_employeeService.UpdateEmployee(employee);
            return await Task.FromResult(Ok(Employee));
        }
    
    }
}