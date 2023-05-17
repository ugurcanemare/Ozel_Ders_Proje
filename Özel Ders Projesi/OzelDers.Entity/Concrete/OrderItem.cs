using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzelDers.Entity.Concrete.Identity;

namespace OzelDers.Entity.Concrete
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public string TeacherId { get; set; }
        public User User { get; set; }
        public decimal? Price { get; set; }
        public int Quantity { get; set; }
    }
}