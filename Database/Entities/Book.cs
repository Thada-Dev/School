using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Database.Entities
{
    public class Book
    {
        public Guid BookGUID { get; set; }

        public string BookName { get; set; } = String.Empty;

        public int BookCode { get; set; }

        public Student? Student { get; set; }

        public Guid StudentGUID { get; set; }
    }
}