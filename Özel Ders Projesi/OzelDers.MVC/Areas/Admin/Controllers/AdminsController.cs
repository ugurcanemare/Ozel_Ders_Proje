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
using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;
using OzelDers.MVC.Areas.Admin.Models.ViewModels.Accounts;

namespace OzelDers.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class AdminsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ITeacherService _teacherService;

        public AdminsController(UserManager<User> userManager, RoleManager<Role> roleManager, ITeacherService teacherService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _teacherService = teacherService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _userManager.GetUsersInRoleAsync("Admin");
            List<AdminViewModel> users = result.Select(a => new AdminViewModel
            {
                UserName = a.UserName,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Email = a.Email,
            }) .ToList();
            return View(users);
        }
    }
}