using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDers.Entity.Concrete.Identity;

namespace OzelDers.Entity.Concrete
{
    public class CartItem
    {
        public int Id { get; set; }
        public string TeacherId { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}