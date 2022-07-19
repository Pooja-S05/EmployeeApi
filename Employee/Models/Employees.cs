using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeId {get;set;}
        public string? Employeename {get;set;}
        public int EmployeeAge { get; set; }
        public string? EmailId { get; set; }
        public string? Password { get; set; }
        public int GenderId { get; set; }
        public string Department { get; set; }=null!;
        public int State { get; set; } 
        
        public string City { get; set; }=null!;

        [ForeignKey("GenderId")]
        [InverseProperty("Employees")]
        public virtual Gender? Genders {get;set;}

        [ForeignKey("StateId")]
        [InverseProperty("Employees")]
         public virtual State? States {get;set;}
        
    }

}