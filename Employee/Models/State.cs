using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Models
{
    public class State
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StateId{ get; set; }
        public string? Name{ get; set; }
        
        [InverseProperty("State")]
        public ICollection<Employees> Employees{get;set;}=null!;

       
    }
}