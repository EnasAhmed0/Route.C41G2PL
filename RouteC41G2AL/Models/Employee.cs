using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteC41G2DAL.Models
{
     public enum Gender{
        male =1, female =2,
       }
    enum Emptype {
         FullTime = 2,
         pPartTime = 1,
    
    }


    public class Employee : ModelBase
    {
       
        [Required(ErrorMessage = "name is Requird")]
        [MaxLength(50, ErrorMessage = "MAX length of name is 50 chars")]
        [MinLength(50, ErrorMessage = "MAX length of name is 50 chars")]
        public string Name { get; set; }
        [Range(22, 30)]

        public int? Age { get; set; }

        [RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$" , ErrorMessage = "Address must be like 123-Street-City-Country")]

          public string Address { get; set; }
        [DataType(DataType.Currency)]
      
         public decimal Salary { get; set; }
        [Display(Name = "Is Active")]
     
       public bool IsActive { get; set; }
        [EmailAddress]
        //[DataType(DataType.EmailAddress)]
       
          public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [Phone]
        //[DataType(DataType.PhoneNumber)]
        
          public string PhoneNumber { get; set; }
        [Display(Name = "Hiring Date")]
        
         public DateTime HiringDate { get; set; }

        public DateTime CrationDate { get; set; }

        public bool IsDateted { get; set; }


        public Gender Gender { get; set; }
        
        
        public int? DepartmentId { get; set; } // foreign KEY 

        //[InverseProperty("Employees")]
        public Department Department { get; set; }












    }






}







