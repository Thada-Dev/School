using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Database.Entities
{
    public class Student
    {
        public Guid StudentGUID { get; set; }

        public string FirstName { get; set; } = String.Empty;

        public string LastName { get; set; } = String.Empty;

        public virtual ICollection<Book> Book { get; }

        public Home Home { get; set; } = null!;

        public virtual ICollection<StudentTeacher> StudentTeacher { get; }

        public Student()
        {
            Book = new List<Book>();
            StudentTeacher = new List<StudentTeacher>();
        }
    }
}