using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.DAL.Interface;
using Employee.Models;
using Employee.Services.Interfaces;

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
            return _employeeRepository.CreateEmployee(employee);
        }
        public bool DeleteEmployee(int EmployeeId)
        {
            return _employeeRepository.DeleteEmployee(EmployeeId);
        }
        public Employees GetEmployee(int EmployeeId)
        {
            return _employeeRepository.GetEmployee(EmployeeId);
        }
        public bool UpdateEmployee(Employees employee)
        {
            return _employeeRepository.UpdateEmployee(employee);
        }
    }
}