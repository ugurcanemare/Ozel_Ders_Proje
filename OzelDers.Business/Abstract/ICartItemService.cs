using OzelDers.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDers.Business.Abstract
{
    public interface ICartItemService
    {
        Task ChangeDateAsync(int cartItemId);
        Task<CartItem> GetByIdAsync(int id);
        void Delete(CartItem cartItem);
        void ClearCart(int cartId);
    }
}
