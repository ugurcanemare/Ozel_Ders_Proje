using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDers.Entity.Abstract;

namespace OzelDers.Entity.Concrete
{
    public class Lesson : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsApproved { get; set; }
        public string Url { get; set; }
        public List<LessonCategory> LessonCategories { get; set; }
        public List<TeacherLesson> TeacherLesson { get; set; }

    }
}