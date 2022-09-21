using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.DTOs.Student
{
    public class StudentRequest
    {        
        [Required]
        [MaxLength(200, ErrorMessage = "FirstName, maximun length 200")]
        public string FirstName { get; set; } = String.Empty;

        [Required]
        [MaxLength(200, ErrorMessage = "LastName, maximun length 200")]
        public string LastName { get; set; } = String.Empty;
    }
}