using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Database.Entities
{
    public class Home
    {
        public Guid HomeGUID { get; set; }

        public string Address { get; set; } = String.Empty;

        public Student Student { get; set; } = null!;

        public Guid StudentGUID { get; set; }
    }
}