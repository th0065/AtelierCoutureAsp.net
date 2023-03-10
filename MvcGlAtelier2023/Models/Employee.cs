using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCGLATELIER2023.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "*"), MaxLength(80)]
        public string Name { get; set; }
        [Required(ErrorMessage = "*"), MaxLength(80)]
        public string Age { get; set; }
        [Required(ErrorMessage = "*")]
        public string State { get; set; }
        [Required(ErrorMessage = "*"), MaxLength(80)]
        public string Country { get; set; }


    }


    public class RapportListeEmployee
    {
       
       
        
        public string Name { get; set; }
       
        public int Age { get; set; }
       
        public string State { get; set; }
      
        public string Country { get; set; }


    }


}