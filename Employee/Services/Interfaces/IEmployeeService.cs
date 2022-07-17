using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Models;

namespace Employee.Services.Interfaces
{
    public interface IEmployeeService
    {
        bool CreateEmployee(Employees employee);
        bool DeleteEmployee(int EmployeeId);
        Employees GetEmployee(int EmployeeId);
        bool UpdateEmployee(Employees employee);
        
    }
}