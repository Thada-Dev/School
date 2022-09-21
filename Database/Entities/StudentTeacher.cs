using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Database.Entities
{
    public class StudentTeacher
    {
        public Student Student { get; set; } = null!;

        public Guid StudentGUID { get; set; }

        public Teacher Teacher { get; set; } = null!;
        
        public Guid TeacherGUID { get; set; }
    }
}