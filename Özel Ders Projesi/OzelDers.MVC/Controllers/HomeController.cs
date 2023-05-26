using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OzelDers.Business.Abstract;
using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;
using OzelDers.MVC.Models.ViewModels;
using OzelDers.MVC.Models.ViewModels.AccountModel.Teachers;
// using OzelDers.MVC.Models;
using System.Diagnostics;

namespace OzelDers.MVC.Controllers
{
    public class HomeController : Controller
    {
          private readonly UserManager<User> _userManager;
        private readonly ITeacherService _teacherService;
        private readonly ILessonService  _lessonService;
        private readonly ICategoryService  _categoryService;

        public HomeController(ITeacherService teacherService, ILessonService lessonService, ICategoryService categoryService, UserManager<User> userManager)
        {
            _teacherService = teacherService;
            _lessonService = lessonService;
            _categoryService = categoryService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()  
        {
            var result = await _teacherService.GetTeacherAsync();
            List<UserViewModel> users = result.Select(t => new UserViewModel
             {
                Id= t.User.Id,
                FirstName= t.User.FirstName,
                LastName=t.User.LastName,
                UserName=t.User.UserName,
                Description = t.User.Description,
                Image = t.User.Image.Url,
                LessonPrice = t.LessonPrice,
                Lessons = t.TeacherLesson.Select(x => x.Lesson).ToList(),
            }).ToList(); 
            return View(users);             
        }

        [HttpGet]
        public async Task<IActionResult> AllTeachers(string categoryurl)
        {
            var result = await _teacherService.GetAllTeachersFullDataAsync(true, categoryurl);
            List<TeacherListViewModel> users = result.Select(t => new TeacherListViewModel
             {
                FirstName= t.User.FirstName,
                LastName=t.User.LastName,
                UserName=t.User.UserName,
                Description = t.User.Description,
                Image = t.User.Image.Url,
                LessonPrice = t.LessonPrice,
                Lessons = t.TeacherLesson.Select(x => x.Lesson).ToList(),
                Categories = t.TeacherCategory.Select(x => x.Category).ToList(),
                
            }).ToList();
            if (RouteData.Values["categoryurl"] != null)
            {
                ViewBag.SelectedCategoryName = await _categoryService.GetCategoryNameByUrlAsync(RouteData.Values["categoryurl"].ToString());
            }
            return View(users);   
        }
    }
}