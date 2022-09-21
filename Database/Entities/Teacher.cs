using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Database.Entities
{
    public class Teacher
    {
        public Guid TeacherGUID { get; set; }

        public string FirstName { get; set; } = String.Empty;

        public string LastName { get; set; } = String.Empty;

        public int Age { get; set; }

        public virtual ICollection<StudentTeacher> StudentTeacher { get; }

        public Teacher()
        {
            StudentTeacher = new List<StudentTeacher>();
        }
    }
}