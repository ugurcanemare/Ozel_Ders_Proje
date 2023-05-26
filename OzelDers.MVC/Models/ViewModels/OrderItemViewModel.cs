using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzelDers.MVC.Models.ViewModels
{
    public class OrderItemViewModel
    {
        public int OrderItemId { get; set; }
        public string TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherUrl { get; set; }
        public decimal? ItemPrice { get; set; }
        public string ImageUrl { get; set; }
    }
}