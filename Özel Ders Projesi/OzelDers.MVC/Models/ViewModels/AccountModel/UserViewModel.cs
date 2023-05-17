using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;

namespace OzelDers.MVC.Models.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public decimal? LessonPrice { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Town { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Image { get; set; }
        public string School { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}