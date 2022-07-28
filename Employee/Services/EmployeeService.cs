using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Employee.DAL.Interface;
using Employee.Models;
using Employee.Services.Interfaces;
using Employee.Services.Validation;

namespace Employee.Services
{
    public class EmployeeService:IEmployeeService
    {
        public readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(IEmployeeRepository employeeRepository,ILogger<EmployeeService> logger)
        {
            _employeeRepository=employeeRepository;
            _logger=logger;
        }
        public bool CreateEmployee(Employees employee)
        {
            validation.ValidateEmployee(employee);
            try{
               return _employeeRepository.CreateEmployee(employee);
            }
            catch (ValidationException exception)
            {
                _logger.LogError("EmployeeService " + "-->"+ "CreateEmployee(Employee employee)" +"-->"+ exception.Message);
                throw;
            }
            catch (Exception exception)
            {
                _logger.LogError("EmployeeService " + "-->"+ "CreateEmployee(Employee employee)" +"-->"+ exception.Message);

                throw exception;
            }
        }
        public bool DeleteEmployee(int EmployeeId)
        {
            try{
            return _employeeRepository.DeleteEmployee(EmployeeId);
            }
            
            catch (Exception exception)
            {
                _logger.LogError("EmployeeService " + "-->"+ "DeleteEmployee(int employeeId)" +"-->"+ exception.Message);

                throw exception;
            }
        }

        public Employees GetEmployee(int EmployeeId)
        {
            try{
                return _employeeRepository.GetEmployee(EmployeeId);
            }
            
            catch (Exception exception)
            {
                _logger.LogError("EmployeeService " + "-->"+ "GetEmployee(int employeeId)" +"-->"+ exception.Message);

                throw exception;
            }
        }
        public bool UpdateEmployee(Employees employee)
        {
            try
            {
                var ExistingEmployee=_employeeRepository.GetEmployee(employee.EmployeeId);
                ExistingEmployee.Employeename=employee.Employeename;
                ExistingEmployee.EmployeeAge=employee.EmployeeAge;
                ExistingEmployee.EmailId=employee.EmailId;
                ExistingEmployee.Password=employee.Password;
            
                ExistingEmployee.Department=employee.Department;
               
                ExistingEmployee.City=employee.City;
                return _employeeRepository.UpdateEmployee(ExistingEmployee);
            }
            
            catch (Exception exception)
            {
                _logger.LogError("EmployeeService " + "-->"+ "UpdateEmployee(Employee employee)" +"-->"+ exception.Message);

                throw exception;
            }
        }
    }
}