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
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository=employeeRepository;
        }
        public bool CreateEmployee(Employees employee)
        {
            validation.ValidateEmployee(employee);
            try{
               return _employeeRepository.CreateEmployee(employee);
            }
            catch (ValidationException exception)
            {
                throw;
            }
            catch (Exception exception)
            {
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
                ExistingEmployee.GenderId=employee.GenderId;
                ExistingEmployee.Department=employee.Department;
                ExistingEmployee.State=employee.State;
                ExistingEmployee.City=employee.City;
                return _employeeRepository.UpdateEmployee(ExistingEmployee);
            }
            
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}