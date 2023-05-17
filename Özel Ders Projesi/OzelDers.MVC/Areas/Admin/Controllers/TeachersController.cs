using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OzelDers.Business.Abstract;
using OzelDers.Entity.Concrete.Identity;
using OzelDers.MVC.Areas.Admin.Models.ViewModels.Accounts;

namespace OzelDers.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class TeachersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ITeacherService _teacherService;

        public TeachersController(UserManager<User> userManager, RoleManager<Role> roleManager, ITeacherService teacherService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _teacherService = teacherService;
        }

        public async Task<IActionResult> Index()
        {
           var result = await _userManager.Users.Where(u => u.Teacher!=null).Include(u => u.Teacher).ThenInclude(u => u.TeacherLesson).ThenInclude(tl=> tl.Lesson).ThenInclude(t => t.LessonCategories).Include(u => u.Image).ToListAsync();
            List<TeacherViewModel> teachers = result.Select(t => new TeacherViewModel
             {
                Id= t.Id,
                FirstName= t.FirstName,
                LastName=t.LastName,
                UserName=t.UserName,
                Email = t.Email,
                Image = t.Image.Url,
                EmailConfirmed = t.EmailConfirmed,
                LessonPrice = t.Teacher.LessonPrice,
                Lessons = t.Teacher.TeacherLesson.Select(x => x.Lesson).ToList(),
            }).ToList();
            return View(teachers); 
        }
    }
    
}