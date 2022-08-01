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
        private readonly ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(EmployeeContext context,ILogger<EmployeeRepository> logger)
        {
            _Context=context;
            _logger=logger;
         
        }
        public bool CreateEmployee(Employees employee)
        {
            try{
                employee.Password=HashPassword.Sha256(employee.Password!);
                _Context.Employees.Add(employee);
                _Context.SaveChanges();
                return true;
            }
            catch (ValidationException exception)
            {
               _logger.LogError("EmployeeRepository " + "-->"+ "CreateEmployee(Employee employee)" +"-->"+ exception.Message);
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
                _Context.Employees!.Remove(ExistingEmployee);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogError("EmployeeRepository " + "-->"+ "DeleteEmployee(int employeeId)" +"-->"+ exception.Message);
                throw exception;
            }
        }
        public Employees GetEmployee(int EmployeeId)
        {
            if(EmployeeId<=0)throw new ArgumentException("EmployeeId must be creater than 0");
            try{
                var Employee=_Context.Employees.Include(e => e.Gender).Include(e=>e.State).FirstOrDefault(item => item.EmployeeId==EmployeeId);
                return Employee!;
            }
            catch (Exception exception)
            {
                _logger.LogError("EmployeeRepository " + "-->"+ "GetEmployee(int employeeId)" +"-->"+ exception.Message);
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
                _logger.LogError("EmployeeRepository " + "-->"+ "UpdateEmployee(Employee employee)" +"-->"+ exception.Message);
                throw exception;
            }
        }
        public Employees login(Login User)
        {
            return _Context.Employees.Where(e => e.EmailId==User.EmailId && e.Password==User.Password).FirstOrDefault();
        } 


       
    }
}