using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Models;

namespace Employee.DAL.Interface
{
    public interface IEmployeeRepository
    {
        bool CreateEmployee(Employees employee);
        bool DeleteEmployee(int EmployeeId);
        Employees GetEmployee(int EmployeeId);
        bool UpdateEmployee(Employees employee);

        Employees login(Login User);
        
    }
}