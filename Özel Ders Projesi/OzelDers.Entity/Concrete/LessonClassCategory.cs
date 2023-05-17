using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzelDers.Entity.Concrete
{
    public class LessonClassCategory
    {
        public int LessonClassId { get; set; }
        public LessonClass LessonClass { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set;}
    }
}