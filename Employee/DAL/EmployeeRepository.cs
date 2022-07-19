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
        private readonly ILogger _logger;
        public EmployeeRepository(EmployeeContext context,ILogger logger)
        {
            _Context=context;
            _logger=logger;
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
                _logger.LogError("EmployeeRespository","CreateEmployee(Employees employee)",exception,employee);
                throw;
            }
            catch (Exception exception)
            {
                _logger.LogError("EmployeeRespository","CreateEmployee(Employees employee)",exception,employee);
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
                _logger.LogError("EmployeeRespository","CreateEmployee(Employees employee)",exception,employee);
                throw exception;
            }
        }
        public Employees GetEmployee(int EmployeeId)
        {
            if(EmployeeId<=0)throw new ArgumentException("EmployeeId must be creater than 0");
            try{
                var Employee=_Context.Employees.Include(e => e.Genders).Include(e =>e.States).FirstOrDefault(item => item.EmployeeId==EmployeeId);
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