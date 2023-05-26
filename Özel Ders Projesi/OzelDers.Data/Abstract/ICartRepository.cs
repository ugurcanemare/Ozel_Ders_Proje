using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Abstract
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task AddToCart(string userId, string teacherId);
        Task<Cart> GetCartByUserId(string userId);
    }
}