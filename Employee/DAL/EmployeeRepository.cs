using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.DAL.Context;
using Employee.DAL.Interface;
using Employee.Models;

namespace Employee.DAL
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly EmployeeContext _Context;
        public EmployeeRepository(EmployeeContext context)
        {
            _Context=context;
        }
        public bool CreateEmployee(Employees employee)
        {
            _Context.Employees.Add(employee);
            _Context.SaveChanges();
            return true;
        }
        public bool DeleteEmployee(int EmployeeId)
        {
            var ExistingEmployee=_Context.Employees.FirstOrDefault(item => item.EmployeeId==EmployeeId);
            _Context.Employees.Remove(ExistingEmployee);
            _Context.SaveChanges();
            return true;
        }
        public Employees GetEmployee(int EmployeeId)
        {
            var Employee=_Context.Employees.FirstOrDefault(item => item.EmployeeId==EmployeeId);
            return Employee;
        }
        public bool UpdateEmployee(Employees employee)
        {
            var Employee=_Context.Employees.Update(employee);
            _Context.SaveChanges();
            return true;
        }
    }
}