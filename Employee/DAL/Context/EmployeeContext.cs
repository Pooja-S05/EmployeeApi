using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee.DAL.Context
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options)
        {
            
        }
        public DbSet<Employees> Employees {get;set;}=null!;
        public DbSet<Gender> Gender{get;set;}=null!;
        public DbSet<State> State{get;set;}=null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasData(new Gender { GenderId = 1, GenderName = "Male" });
                entity.HasData(new Gender { GenderId = 2, GenderName= "Female" });
                entity.HasKey("GenderId");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasData(new State { StateId = 1, Name = "Tamil Nadu" });
                entity.HasData(new State { StateId = 2, Name= "Kerala" });
                entity.HasKey("StateId");
            });
        }
    }
}