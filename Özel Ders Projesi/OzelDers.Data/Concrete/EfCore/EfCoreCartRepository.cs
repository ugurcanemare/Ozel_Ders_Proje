using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OzelDers.Data.Abstract;
using OzelDers.Data.Concrete.EfCore.Context;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Concrete.EfCore
{
    public class EfCoreCartRepository : EfCoreGenericRepository<Cart>, ICartRepository
    {
        public EfCoreCartRepository(OzelDersContext _appContext) : base(_appContext)
        {
        }
        OzelDersContext AppContext
        {
            get { return _dbContext as OzelDersContext; }
        }

        public async Task AddToCart(string userId, string teacherId)
        {
            var cart = await GetCartByUserId(userId);
            if (cart != null)
            {
                var index = cart.CartItems.FindIndex(ci => ci.TeacherId == teacherId);
                if (index < 0)//Ürün daha önceden sepete eklenmemişse
                {
                    cart.CartItems.Add(new CartItem
                    {
                        TeacherId = teacherId,
                        CartId = cart.Id
                    });
                }
                AppContext.Carts.Update(cart);
                await AppContext.SaveChangesAsync();
            }
        }

        public async Task<Cart> GetCartByUserId(string userId)
        {
            return await AppContext
                .Carts
                .Include(c => c.CartItems)
                .Include(ci => ci.User)
                .ThenInclude(ci => ci.Image)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }
    }
}