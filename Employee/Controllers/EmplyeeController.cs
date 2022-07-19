using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public readonly ILogger _Logger;
        public EmplyeeController(IEmployeeService employeeService,ILogger logger)
        {
            _employeeService=employeeService;
            _Logger=logger;
        }
        [HttpPost]
        public async Task<ActionResult> CreateEmployee(Employees employee)
        {
            if(employee==null)return BadRequest("Null value cant be posted");
            try
            {
                return _employeeService.CreateEmployee(employee)? await Task.FromResult(Ok("Created Successfully")):BadRequest("Error Occured while creating Employee");
            }
            catch(ValidationException exception)
            {
                _Logger.LogError("EmployeeController","CreateEmployee(Employees employee)",exception,employee);
                return BadRequest("validation error occured");
            }
            catch(Exception exception)
            {
                _Logger.LogError("EmployeeController","CreateEmployee(Employees employee)",exception,employee);
                return Problem("Error Occured While creating employee");
            }
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteEmployee(int EmployeeId)
        {
            if(EmployeeId<=0)return BadRequest("EmployeeId must be greater than 0");
            try{
                return _employeeService.DeleteEmployee(EmployeeId)? await Task.FromResult(Ok("Successfully Deleted")):BadRequest("Error Occured While Deleting the record");
            }
           
            catch(Exception exception)
            {
                _Logger.LogError("EmployeeController","DeleteEmployee(int EmployeeId)",exception,EmployeeId);
                return Problem("Error Occured While creating employee");
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetEmployee(int EmployeeId)
        {
            if(EmployeeId<=0)return BadRequest("EmployeeId must be greater than 0");
             try{
                var Employee=_employeeService.GetEmployee(EmployeeId);
                return await Task.FromResult(Ok(Employee));
             }
             catch(Exception exception)
            {
                _Logger.LogError("EmployeeController","GetEmployee(int EmployeeId)",exception,EmployeeId);
                return Problem("Error Occured While creating employee");
            }

            
        }
        [HttpPatch]
        public async Task<ActionResult> UpdateEmployee(Employees employee)
        {
            try{
                var Employee=_employeeService.UpdateEmployee(employee);
                return await Task.FromResult(Ok(Employee));
            }
            
            catch(Exception exception)
            {
                _Logger.LogError("EmployeeController","UpdateEmployee(Employee employee)",exception,employee);
                return Problem("Error Occured While creating employee");
            }
        }
    
    }
}