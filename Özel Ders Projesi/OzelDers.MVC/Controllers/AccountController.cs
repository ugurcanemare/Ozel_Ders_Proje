using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OzelDers.Business.Abstract;
using OzelDers.Core;
using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;
using OzelDers.MVC.Models.ViewModels.AccountModel;
using OzelDers.MVC.Models.ViewModels.AccountModel.Teachers;
using OzelDers.MVC.Models.ViewModels.AccountModel.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using OzelDers.MVC.EmailServices;

namespace OzelDers.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;
        private readonly ILessonService  _lessonService;
        private readonly ICategoryService  _categoryService;
        private readonly ILessonClassService  _lessonClassService;
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly IEmailSender _emailSender;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ITeacherService teacherService, ILessonService lessonService, ICategoryService categoryService, IStudentService studentService, ILessonClassService lessonClassService, ICartService cartService, IOrderService orderService, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _teacherService = teacherService;
            _lessonService = lessonService;
            _categoryService = categoryService;
            _studentService = studentService;
            _lessonClassService = lessonClassService;
            _cartService = cartService;
            _orderService = orderService;
            _emailSender = emailSender;
        }
        [HttpGet]
        public async Task<IActionResult> RegisterTeacher()
        {
            List<Lesson> lessons = await _lessonService.GetAllAsync();
            List<Category> categories = await _categoryService.GetAllAsync();
            TeacherViewModel teacherViewModel = new TeacherViewModel
            {
                Categories = categories,
                Lessons = lessons
            };
            return View(teacherViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> RegisterTeacher(TeacherViewModel teacherViewModel)
        {
            if(ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = teacherViewModel.UserName,
                    FirstName = teacherViewModel.FirstName,
                    Description = teacherViewModel.Description,
                    LastName = teacherViewModel.LastName,
                    Email = teacherViewModel.Email,
                    Url = Jobs.GetUrl(teacherViewModel.UserName),
                    PhoneNumber = teacherViewModel.PhoneNumber,
                    Town = teacherViewModel.Town,
                    School = teacherViewModel.School,
                    DateOfBirth = teacherViewModel.DateOfBirth,
                    City = teacherViewModel.City,
                    Gender = teacherViewModel.Gender,
                    Image = new Image
                        {
                            CreatedDate=DateTime.Now,
                            ModifiedDate=DateTime.Now,
                            IsApproved=true,
                            Url=Jobs.UploadImage(teacherViewModel.Image)
                        }
                };
                Teacher teacher = new Teacher(){
                    LessonPrice = teacherViewModel.LessonPrice,
                    Department = teacherViewModel.Department,
                    UserId = user.Id
                };

                var result = await _userManager.CreateAsync(user,teacherViewModel.Password);
                await _teacherService.CreateUser(user,teacher,teacherViewModel.SelectedLessons,teacherViewModel.SelectedCategories);
                if(result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user,"Teacher");
                    await _cartService.InitializeCart(user.Id);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var url = Url.Action("ConfirmEmail","Account", new
                    {
                        userId = user.Id,
                        token = code
                    });
                    await _emailSender.SendEmailAsync(teacherViewModel.Email,"BooksApp Uygulaması Üye Onay Maili",$"<h3>Hoşgeldiniz! Son bir adım kaldı!</h3>Sayın {teacherViewModel.FirstName} {teacherViewModel.LastName} <br> Lütfen hesabınızı onaylamak için <a href='http://localhost:5265{url}'>tıklayınız.</a>");
                    TempData["Message"] = Jobs.CreateMessage("Kayıt İşlemi", "Kaydınız başarıyla oluşturulmuştur.", "success");
                    return RedirectToAction("Index", "Home");
                }
               return RedirectToAction("Index");
            }
            List<Lesson> lessons = await _lessonService.GetAllAsync();
            List<Category> categories = await _categoryService.GetAllAsync();
            teacherViewModel.Lessons = lessons;
            teacherViewModel.Categories = categories;
            TempData["Message"] = Jobs.CreateMessage("HATA", "Bir hata oluştu, tekrar deneyiniz", "danger");
            return View(teacherViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> RegisterStudent()
        {
            var Category = await _categoryService.GetAllAsync();
            var LessonClass = await  _lessonClassService.GetAllAsync();
            var category = Category.Select(c => new SelectListItem 
            {
                Text = c.Name,
                Value = c.Name
            });
            ViewBag.Category = category;
            var lessonClass = LessonClass.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Name
            });
            ViewBag.LessonClass = lessonClass;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterStudent(StudentViewModel studentViewModel)
        {
            if(ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = studentViewModel.UserName,
                    FirstName = studentViewModel.FirstName,
                    LastName = studentViewModel.LastName,
                    Description = studentViewModel.Description,
                    DateOfBirth = studentViewModel.DateOfBirth,
                    Email = studentViewModel.Email,
                    School = studentViewModel.School,
                    Url = Jobs.GetUrl(studentViewModel.UserName),
                    PhoneNumber = studentViewModel.PhoneNumber,
                    Town = studentViewModel.Town,      
                    City = studentViewModel.City,
                    Gender = studentViewModel.Gender,
                    Image = new Image
                        {
                            CreatedDate=DateTime.Now,
                            ModifiedDate=DateTime.Now,
                            IsApproved=true,
                            Url=Jobs.UploadImage(studentViewModel.Image)
                        }
                };
                Student student = new Student{
                    Category = studentViewModel.Category,
                    LessonClass = studentViewModel.LessonClass,
                    UserId = user.Id
                };

                var result = await _userManager.CreateAsync(user,studentViewModel.Password);
                await _studentService.CreateUser(user,student);
                if(result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user,"Student");
                    await _cartService.InitializeCart(user.Id);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var url = Url.Action("ConfirmEmail","Account", new
                    {
                        userId = user.Id,
                        token = code
                    });
                    await _emailSender.SendEmailAsync(studentViewModel.Email,"BooksApp Uygulaması Üye Onay Maili",$"<h3>Hoşgeldiniz! Son bir adım kaldı!</h3>Sayın {studentViewModel.FirstName} {studentViewModel.LastName} <br> Lütfen hesabınızı onaylamak için <a href='http://localhost:5265{url}'>tıklayınız.</a>");
                    return RedirectToAction("Index", "Home");
                }
               return RedirectToAction("Index");
            }
            return View(studentViewModel);
        }
        [HttpGet]
        public IActionResult Login(string returnUrl=null)
        {
            return View(new LoginViewModel { ReturnUrl=returnUrl});
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
             if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(loginViewModel.UserName);
                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı bilgileri hatalı!");
                    return View(loginViewModel);
                }
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, isPersistent: true, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    return Redirect(loginViewModel.ReturnUrl ?? "/");
                }
                ModelState.AddModelError("", "Kullanıcı adı ya da parola hatalı!");
            }
            return View(loginViewModel);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> TeacherManage(string id)
        {
            string name = id;
            if (String.IsNullOrEmpty(name))
            {
                return NotFound();
            }
            var result = await _userManager.Users.Include(x=>x.Image).Include(x=>x.Teacher).ThenInclude(t => t.TeacherCategory).Include(x => x.Teacher).ThenInclude(t => t.TeacherLesson).ThenInclude(tl => tl.Lesson).ToListAsync();
            User user = await _userManager.FindByNameAsync(name);
            if (user == null)
            {
                return NotFound();
            }
            TeacherManageViewModel teacherManageViewModel = new TeacherManageViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                LessonPrice = user.Teacher.LessonPrice,
                Description = user.Description,
                DateOfBirth = user.DateOfBirth,
                UserName = user.UserName,
                Department = user.Teacher.Department,
                School = user.School,
                City = user.City,
                Town = user.Town,
                Email = user.Email,
                SelectedLessons = user.Teacher.TeacherLesson.Select(tl => tl.Lesson.Id).ToArray(),
                SelectedCategories = user.Teacher.TeacherCategory.Select(tl => tl.CategoryId).ToArray(),
                PhoneNumber = user.PhoneNumber,
                Img = user.Image.Url
            };
            List<Lesson> lessons = await _lessonService.GetAllAsync();
            List<Category> categories = await _categoryService.GetAllAsync();
            teacherManageViewModel.Categories = categories;
            teacherManageViewModel.Lessons = lessons;

            return View(teacherManageViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> TeacherManage(TeacherManageViewModel teacherManageViewModel)
        {
            if (teacherManageViewModel == null) { return NotFound(); }
            User user = await _userManager.FindByIdAsync(teacherManageViewModel.Id);
            bool logOut = !(user.UserName == teacherManageViewModel.UserName);
            user.FirstName = teacherManageViewModel.FirstName;
            user.LastName = teacherManageViewModel.LastName;   
            user.Gender = teacherManageViewModel.Gender;
            user.Town = teacherManageViewModel.Town;
            user.Description = teacherManageViewModel.Description;
            user.UserName = teacherManageViewModel.UserName;
            user.City = teacherManageViewModel.City;
            user.Email = teacherManageViewModel.Email;
            user.DateOfBirth = teacherManageViewModel.DateOfBirth;
            if (teacherManageViewModel.Image != null)
                {
                    Image images = new Image
                    {
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        IsApproved = true,
                        Url = Jobs.UploadImage(teacherManageViewModel.Image),
                        UserId = user.Id
                    };
                }
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                if (logOut)
                {
                    return RedirectToAction("Logout");
                }
                await _teacherService.UpdateUser(user,teacherManageViewModel.SelectedLessons,teacherManageViewModel.SelectedCategories);
                return Redirect("/Account/TeacherManage/" + user.UserName);
            };
               
            List<Lesson> lessons = await _lessonService.GetAllAsync();
            List<Category> categories = await _categoryService.GetAllAsync();
            teacherManageViewModel.Categories = categories;
            teacherManageViewModel.Lessons = lessons;
            return View(teacherManageViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> StudentManage(string id)
        {
            string name = id;
            if (String.IsNullOrEmpty(name))
            {
                return NotFound();
            }
            var result = await _userManager.Users.Include(x=>x.Image).Include(x=>x.Student).ToListAsync();
            User user = await _userManager.FindByNameAsync(name);
            if (user == null)
            {
                return NotFound();
            }
            var Category = await _categoryService.GetAllAsync();
            var LessonClass = await  _lessonClassService.GetAllAsync();
            var category = Category.Select(c => new SelectListItem 
            {
                Text = c.Name,
                Value = c.Name
            });
            ViewBag.Category = category;
            var lessonClass = LessonClass.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Name
            });
            ViewBag.LessonClass = lessonClass;
            
            StudentManageViewModel studentManageViewModel = new StudentManageViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                Description = user.Description,
                DateOfBirth = user.DateOfBirth,
                UserName = user.UserName,
                School = user.School,
                Category = user.Student.Category,
                City = user.City,
                LessonClass = user.Student.LessonClass,
                Town = user.Town,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Img = user.Image.Url
            };
            return View(studentManageViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> StudentManage(StudentManageViewModel studentManageViewModel)
        {
            if (studentManageViewModel == null) { return NotFound(); }

            User user = await _userManager.FindByIdAsync(studentManageViewModel.Id);
            var student = await _studentService.GetStudentByUserId(user.Id);
            bool logOut = !(user.UserName == studentManageViewModel.UserName);
            user.FirstName = studentManageViewModel.FirstName;
            user.LastName = studentManageViewModel.LastName;   
            user.Description = studentManageViewModel.Description;
            user.School = studentManageViewModel.School;
            user.Gender = studentManageViewModel.Gender;
            user.Town = studentManageViewModel.Town;
            user.Description = studentManageViewModel.Description;
            user.UserName = studentManageViewModel.UserName;
            user.City = studentManageViewModel.City;
            if(studentManageViewModel.Category!=user.Student.Category) {
                user.Student.Category = studentManageViewModel.Category;
                };
            if(studentManageViewModel.LessonClass!=user.Student.LessonClass){
                user.Student.LessonClass = studentManageViewModel.LessonClass;
                };
            user.Email = studentManageViewModel.Email;
            user.DateOfBirth = studentManageViewModel.DateOfBirth;
            if (studentManageViewModel.Image != null)
                {
                    Image images = new Image
                    {
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        IsApproved = true,
                        Url = Jobs.UploadImage(studentManageViewModel.Image),
                        UserId = user.Id
                    };
                }
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                if (logOut)
                {
                    return RedirectToAction("Logout");
                }
                return Redirect("/Account/StudentManage/" + user.UserName);
            };
            return View(studentManageViewModel);
        }
         public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if(userId == null || token == null)
            {
                return View();
            }
            User user = await _userManager.FindByIdAsync(userId);
            if(user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if(result.Succeeded)
                {
                    TempData["Message"] = Jobs.CreateMessage("Başarılı", "Profiliniz başarıyla onaylanmıştır. Güvenli alışverişler", "success");
                    return View();
                }
            }
            TempData["Message"] = Jobs.CreateMessage("HATA", "Profiliniz onaylanırken bir hata oluştu, detaylı bilgi için 0212 689 53 93", "danger");
            return View();
        }
    }
}