using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OzelDers.Business.Abstract;
using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;
using OzelDers.MVC.Models.ViewModels;

namespace OzelDers.MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;
        private readonly IOrderService _orderService;
        private readonly INotyfService _notyfService;
        private readonly ITeacherService _teacherService;

        public CartController(UserManager<User> userManager, ICartService cartService, ICartItemService cartItemService, IOrderService orderService, INotyfService notyfService, ITeacherService teacherService)
        {
            _userManager = userManager;
            _cartService = cartService;
            _cartItemService = cartItemService;
            _orderService = orderService;
            _notyfService = notyfService;
            _teacherService = teacherService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var cart = await _cartService.GetCartByUserId(userId);
            var teacher = await  _teacherService.GetTeacherByUserNameAsync(cart.CartItems.Select(ci => ci.TeacherId).FirstOrDefault());
            CartViewModel cartViewModel = new CartViewModel
            {
                CartId = cart.Id,
                CartItems = cart
                    .CartItems
                    .Select(ci => new CartItemViewModel
                    {
                        CartItemId=ci.Id,
                        TeacherId = cart.CartItems.Select(ci => ci.TeacherId).FirstOrDefault(),
                        TeacherName = teacher.User.FirstName + " " + teacher.User.LastName,
                        ItemPrice= teacher.LessonPrice,
                        ImageUrl = teacher.User.Image.Url,
                    }).ToList()
            };
            return View(cartViewModel);
        }
        [HttpPost]
        public IActionResult AddToCart(string id)
        {
            var userId = _userManager.GetUserId(User);
            _cartService.AddToCart(userId, id);
            _notyfService.Success("Ürün sepetinize başarıyla eklenmiştir");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteFromCart(int id)
        {
            var cartItem = await _cartItemService.GetByIdAsync(id);
            _cartItemService.Delete(cartItem);
            _notyfService.Information("Ürün sepetten kaldırılmıştır",2);
            return RedirectToAction("Index");
        }
        public IActionResult ClearCart(int id)
        {
            _cartItemService.ClearCart(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var userId = _userManager.GetUserId(User);
            var cart = await _cartService.GetCartByUserId(userId);
            var teacher = await  _teacherService.GetTeacherByUserNameAsync(cart.CartItems.Select(ci => ci.TeacherId).FirstOrDefault());
            OrderViewModel orderViewModel = new OrderViewModel
            {
                FirstName = cart.User.FirstName,
                LastName = cart.User.LastName,
                City = cart.User.City,
                Town = cart.User.Town,
                Phone = cart.User.PhoneNumber,
                Email = cart.User.Email,
                Cart = new CartViewModel
                {
                    CartId=cart.Id,
                    CartItems=cart.CartItems.Select(ci=>new CartItemViewModel
                    {
                        CartItemId=ci.Id,
                        TeacherId = cart.CartItems.Select(ci => ci.TeacherId).FirstOrDefault(),
                        TeacherName = teacher.User.FirstName + " " + teacher.User.LastName,
                        ItemPrice= teacher.LessonPrice,
                        ImageUrl = teacher.User.Image.Url,
                    }).ToList(),
                }
            };
            return View(orderViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(OrderViewModel orderViewModel)
        {
            var userId = _userManager.GetUserId(User);
            var cart = await _cartService.GetCartByUserId(userId);
            var teacher = await  _teacherService.GetTeacherByUserNameAsync(cart.CartItems.Select(ci => ci.TeacherId).FirstOrDefault()); 
            if (ModelState.IsValid)
            {
                orderViewModel.Cart = new CartViewModel
                {
                    CartId=cart.Id,
                    CartItems=cart.CartItems.Select(ci=>new CartItemViewModel
                    {
                        CartItemId=ci.Id,
                        TeacherId = cart.CartItems.Select(ci => ci.TeacherId).FirstOrDefault(),
                        TeacherName = teacher.User.FirstName + " " + teacher.User.LastName,
                        ItemPrice= teacher.LessonPrice,
                        ImageUrl = teacher.User.Image.Url,
                    }).ToList(),
                };

                if (!CardNumberControl(orderViewModel.CardNumber))
                {
                    _notyfService.Error("Geçersiz kart numarası!");
                    return View(orderViewModel);
                }

                Payment payment = PaymentProcess(orderViewModel);
                if (payment.Status == "success")
                {
                    SaveOrder(orderViewModel, userId);
                    _cartItemService.ClearCart(orderViewModel.Cart.CartId);
                    _notyfService.Success("Ödemeniz alınmış ve siparişiniz oluşturulmuştur!");
                    return RedirectToAction("Index", "Home");
                }
                _notyfService.Error("Bir sorun oluştu!");
            }
            orderViewModel.Cart = new CartViewModel
            {
                CartId=cart.Id,
                CartItems=cart.CartItems.Select(ci=>new CartItemViewModel
                {
                    CartItemId=ci.Id,
                    TeacherId = cart.CartItems.Select(ci => ci.TeacherId).FirstOrDefault(),
                    TeacherName = teacher.User.FirstName + " " + teacher.User.LastName,
                    ItemPrice= teacher.LessonPrice,
                    ImageUrl = teacher.User.Image.Url,
                }).ToList()
            };
            return View(orderViewModel);
        }
        [NonAction]
        private async void SaveOrder(OrderViewModel orderViewModel, string userId)
        {
            Order order = new Order();
            order.OrderState = EnumOrderState.Unpaid;
            order.OrderType = EnumOrderType.CreditCard;
            order.OrderDate = DateTime.Now;
            order.FirstName = orderViewModel.FirstName;
            order.LastName = orderViewModel.LastName;
            order.NormalizedName=(orderViewModel.FirstName+orderViewModel.LastName).ToUpper();
            order.Phone= orderViewModel.Phone;
            order.Email = orderViewModel.Email;
            order.Address = orderViewModel.Town;
            order.City= orderViewModel.City;
            order.UserId= userId;
            order.OrderItems = new List<Entity.Concrete.OrderItem>();
            foreach (var cartItem in orderViewModel.Cart.CartItems)
            {
                Entity.Concrete.OrderItem orderItem = new Entity.Concrete.OrderItem();
                orderItem.Price = cartItem.ItemPrice;
                orderItem.TeacherId = cartItem.TeacherId;
                order.OrderItems.Add(orderItem);
            }
            await _orderService.CreateAsync(order);
        }
        [NonAction]
        private bool CardNumberControl(string cardNumber)
        {
            cardNumber = cardNumber.Replace("-", "").Replace(" ", "");
            if (cardNumber.Length != 16) return false;
            foreach (var chr in cardNumber)
            {
                if (!Char.IsNumber(chr)) return false;
            }
            int oddTotal = 0;
            int ovenTotal = 0;
            for (int i = 0; i < cardNumber.Length; i+=2)
            {
                int nextOddNumber = Convert.ToInt32(cardNumber[i].ToString());
                int nextOvenNumber = Convert.ToInt32(cardNumber[i + 1].ToString());
                int addedOddNumber = nextOddNumber * 2;
                addedOddNumber = addedOddNumber >= 10 ? addedOddNumber - 9 : addedOddNumber;
                oddTotal += addedOddNumber;
                ovenTotal += nextOvenNumber;
            }
            int total = oddTotal + ovenTotal;
            bool isValidNumber = total % 10 == 0 ? true : false;
            return isValidNumber;
        }
        private Payment PaymentProcess(OrderViewModel orderViewModel)
        {
            #region Payment Options Created
            Options options = new Options();
            options.ApiKey = "sandbox-kBV9yENXNfPvZGI99A2Yzq2g4WlXWXGK";
            options.SecretKey = "sandbox-IZjD1f7pY0lLd2llF1ejVimdiO53tSqh";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";
            #endregion
            #region Create Payment Request
            CreatePaymentRequest request = new CreatePaymentRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId=new Random().Next(1000000,9999999).ToString(),
                Price = Convert.ToInt32(orderViewModel.Cart.TotalPrice()).ToString(),
                PaidPrice= Convert.ToInt32(orderViewModel.Cart.TotalPrice()).ToString(),
                Currency = Currency.TRY.ToString(),
                Installment=1,
                BasketId=orderViewModel.Cart.CartId.ToString(),
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.PRODUCT.ToString(),
                PaymentCard = new PaymentCard
                {
                    CardHolderName= orderViewModel.CardName,
                    CardNumber=orderViewModel.CardNumber,
                    ExpireMonth = orderViewModel.ExpirationMonth,
                    ExpireYear=orderViewModel.ExpirationYear,
                    Cvc=orderViewModel.Cvc,
                    RegisterCard=0
                },
                Buyer = new Buyer
                {
                    Id="BY999",
                    Name=orderViewModel.FirstName,
                    Surname=orderViewModel.LastName,
                    GsmNumber=orderViewModel.Phone,
                    Email = orderViewModel.Email,
                    IdentityNumber="87955588899",
                    RegistrationAddress=orderViewModel.City + "/"+ orderViewModel.Town,
                    Ip="84.99.155.212",
                    Country="Türkiye",
                    ZipCode="34700",
                    City=orderViewModel.City,
                },
                
               
            };
            Address billingAddress = new Address();

            billingAddress.ContactName = orderViewModel.FirstName + " " + orderViewModel.LastName;
                 billingAddress.City = orderViewModel.City;
                 billingAddress.Country = "Türkiye";
                 billingAddress.Description = " asdasdas";
                 billingAddress.ZipCode = "123456";
            request.BillingAddress=billingAddress;
            Address shippingAddress = new Address();

                shippingAddress.Description = "asdasd";
                shippingAddress.ZipCode = "123412";
                shippingAddress.ContactName = "asdasd";
                shippingAddress.City = "asd";
                shippingAddress.Country = "Türkiye";
            
            request.ShippingAddress = shippingAddress;
            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem basketItem;
            foreach (var item in orderViewModel.Cart.CartItems)
            {
                basketItem = new BasketItem
                {
                    Id = item.CartItemId.ToString(),
                    Name = item.TeacherName.ToString(),
                    Category1 = "Ders",
                    ItemType = BasketItemType.PHYSICAL.ToString(),
                    Price = Convert.ToInt32(item.ItemPrice).ToString()
                };
                basketItems.Add(basketItem);    
            }
            request.BasketItems = basketItems;
            #endregion
            Payment payment = Payment.Create(request, options);
            return payment;
        }
    }
}