using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzelDers.Entity.Concrete
{
    public class LessonCategory
    {
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}