using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OzelDers.MVC.Models.ViewModels
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }
        public decimal? TotalPrice()
        {
            return CartItems.Sum(ci => ci.ItemPrice);
        }
    }
     public class CartItemViewModel
    {
        public int CartItemId { get; set; }
        public string TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherUrl { get; set; }
        public string Description { get; set; }
        public decimal? ItemPrice { get; set; }
        public string ImageUrl { get; set; }
    }
}