using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OzelDers.Business.Abstract;
using OzelDers.Entity.Concrete.Identity;
using OzelDers.MVC.Models.ViewModels;

namespace OzelDers.MVC.Controllers
{
    public class TeachersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<User> _userManager;

        public TeachersController(IOrderService orderService, UserManager<User> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var orderList = await _orderService.GetAllOrdersAsync(null, false);
            List<OrderViewModel> orders = orderList.Select(o => new OrderViewModel
            {
                Id = o.Id,
                Town = o.Address,
                City = o.City,
                Phone = o.Phone,
                Email = o.Email,
                FirstName = o.FirstName,
                LastName = o.LastName,
                OrderDate = o.OrderDate
            }).ToList();
            return View(orders);
        }
    }
}