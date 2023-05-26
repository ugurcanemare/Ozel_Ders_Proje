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

    public class StudentsController : Controller
    {
         private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ITeacherService _teacherService;

        public StudentsController(UserManager<User> userManager, RoleManager<Role> roleManager, ITeacherService teacherService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _teacherService = teacherService;
        }

        public async Task<IActionResult> Index()
        {
           var result = await _userManager.Users.Where(u => u.Student!=null).Include(u => u.Student).Include(u => u.Image).ToListAsync();
            List<StudentViewModel> students = result.Select(t => new StudentViewModel
             {
                Id= t.Id,
                FirstName= t.FirstName,
                LastName=t.LastName,
                UserName=t.UserName,
                Email = t.Email,
                Image = t.Image.Url,

            }).ToList();
            
            return View(students); 
        }
    }
}