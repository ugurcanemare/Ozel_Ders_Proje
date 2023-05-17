using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Abstract
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        void ClearCart(int cartId);
        Task ChangeDateAsync(CartItem cartItem);
    }
}