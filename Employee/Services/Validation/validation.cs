using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Employee.Models;

namespace Employee.Services.Validation
{
    public class validation
    {
        public static bool ValidateEmployee(Employees employee)
        {
            if(employee==null)throw new ValidationException("Employee should not be null");
            if(employee.Employeename.Length<2)throw new ValidationException("Employee Name should have the words greater than 2");
            if(employee.EmployeeAge<18)throw new ValidationException("Age must be greater than 18");
            
            else return true;
        }
    }
}