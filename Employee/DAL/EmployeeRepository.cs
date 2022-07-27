using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Employee.DAL.Context;
using Employee.DAL.Interface;
using Employee.Models;
using Microsoft.EntityFrameworkCore;

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
            try{
                _Context.Employees.Add(employee);
                _Context.SaveChanges();
                return true;
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
             if(EmployeeId<=0)throw new ArgumentException("EmployeeId must be creater than 0");
            try{
                var ExistingEmployee=_Context.Employees.FirstOrDefault(item => item.EmployeeId==EmployeeId);
                _Context.Employees.Remove(ExistingEmployee);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                
                throw exception;
            }
        }
        public Employees GetEmployee(int EmployeeId)
        {
            if(EmployeeId<=0)throw new ArgumentException("EmployeeId must be creater than 0");
            try{
                var Employee=_Context.Employees.Include(e => e.Gender).Include(e=>e.State).FirstOrDefault(item => item.EmployeeId==EmployeeId);
                return Employee;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public bool UpdateEmployee(Employees employee)
        {
            try{
                var Employee=_Context.Employees.Update(employee);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}