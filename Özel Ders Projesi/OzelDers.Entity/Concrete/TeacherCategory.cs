using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzelDers.Entity.Concrete
{
    public class TeacherCategory
    {
         public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher {get; set; }
    }
}