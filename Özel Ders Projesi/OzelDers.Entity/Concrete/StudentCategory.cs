using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzelDers.Entity.Concrete
{
    public class StudentCategory
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}