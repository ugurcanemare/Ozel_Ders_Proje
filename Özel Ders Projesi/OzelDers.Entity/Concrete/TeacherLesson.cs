using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzelDers.Entity.Concrete
{
    public class TeacherLesson
    {
         public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher {get; set; }
    }
}