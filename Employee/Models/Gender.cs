using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Models
{
    public class Gender
    {

        
        public Gender()
        {
        }

        [Key][DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GenderId{get;set;}
        public string? GenderName{get;set;}


        [InverseProperty("Genders")]
        public virtual ICollection<Employees> Employees {get;set;}=null!;

    }
}