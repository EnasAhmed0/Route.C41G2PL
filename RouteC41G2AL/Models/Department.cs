using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteC41G2DAL.Models
{
    // model 
    internal class Department
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Code is Required ya hamada!!")]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; } = DateTime.Now;








    }
}
