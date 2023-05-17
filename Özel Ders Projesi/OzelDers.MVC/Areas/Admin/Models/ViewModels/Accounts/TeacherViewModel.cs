using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDers.Entity.Concrete;

namespace OzelDers.MVC.Areas.Admin.Models.ViewModels.Accounts
{
    public class TeacherViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public decimal? LessonPrice { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public List<Lesson> Lessons { get; set;}
        public bool EmailConfirmed { get; set; }
    }
}