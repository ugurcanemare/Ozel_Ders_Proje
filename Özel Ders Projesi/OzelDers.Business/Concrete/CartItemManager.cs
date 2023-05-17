using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDers.Business.Abstract;
using OzelDers.Data.Abstract;
using OzelDers.Entity.Concrete;

namespace OzelDers.Business.Concrete
{
    public class CartItemManager : ICartItemService
    {
        ICartItemRepository _cartItemRepository;

        public CartItemManager(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task ChangeDateAsync(int cartItemId)
        {
            var cartItem = await _cartItemRepository.GetByIdAsync(cartItemId);
            await _cartItemRepository.ChangeDateAsync(cartItem);
        }

        public void ClearCart(int cartId)
        {
            _cartItemRepository.ClearCart(cartId);
        }

        public void Delete(CartItem cartItem)
        {
            _cartItemRepository.Delete(cartItem);
        }

        public async Task<CartItem> GetByIdAsync(int id)
        {
            return await _cartItemRepository.GetByIdAsync(id);
        }
    }
}