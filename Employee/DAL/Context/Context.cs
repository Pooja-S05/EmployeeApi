using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee.DAL.Context
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options):base(options)
        {
            
        }
        public DbSet<Employees> Employees {get;set;}=null!;
    }
}