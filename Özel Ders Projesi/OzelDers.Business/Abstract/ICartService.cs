
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzelDers.Entity.Concrete;

namespace OzelDers.Business.Abstract
{
    public interface ICartService
    {
        Task InitializeCart(string userId);
        Task AddToCart(string userId,string teacherId);
        Task<Cart> GetByIdAsync(int id);
        Task<Cart> GetCartByUserId(string userId);
    }
}
