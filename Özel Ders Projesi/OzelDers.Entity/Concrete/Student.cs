using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDers.Entity.Concrete.Identity;

namespace OzelDers.Entity.Concrete
{
    public class Student
    {
        public int Id { get; set; }
        public bool IsApproved { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public string LessonClass { get; set; }
        public string Category { get; set; }
    }
}