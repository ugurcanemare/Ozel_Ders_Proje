using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzelDers.Entity.Concrete
{
    public class StudentClass
    {
        public int ClassId { get; set; }
        public LessonClass Class { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}