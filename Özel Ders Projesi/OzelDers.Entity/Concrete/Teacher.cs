using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDers.Entity.Concrete.Identity;

namespace OzelDers.Entity.Concrete
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Department { get; set; }
        public decimal? LessonPrice { get; set; }
        public int Quantity { get; set; }
        public List<TeacherLesson> TeacherLesson { get; set; }
         public List<TeacherCategory> TeacherCategory { get; set; }
         public bool IsApproved { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}