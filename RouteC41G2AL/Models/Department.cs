using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteC41G2DAL.Models
{
    // model 
    public class Department : ModelBase
    {
        [Required (ErrorMessage ="Code is Required ya hamada!!")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Name is Required ya hamada!!")]
        public string Name { get; set; }

        [Display(Name ="Date Of Creation")]
        public DateTime DateOfCreation { get; set; } = DateTime.Now;

        public int? EmployeeId { get; set; } // foreign KEY 

        //[InverseProperty("Employees")]


        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();






    }
}
