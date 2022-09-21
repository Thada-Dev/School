using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.DTOs.Student
{
    public class StudentResponse
    {
        public Guid StudentGUID { get; set; }

        public string FirstName { get; set; } = String.Empty;

        public string LastName { get; set; } = String.Empty;
    }
}