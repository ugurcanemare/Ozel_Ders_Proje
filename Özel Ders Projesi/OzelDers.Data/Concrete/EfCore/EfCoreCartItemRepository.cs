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
    public class EfCoreCartItemRepository : EfCoreGenericRepository<CartItem>, ICartItemRepository
    {
        public EfCoreCartItemRepository(OzelDersContext _appContext) : base(_appContext)
        {
        }
        OzelDersContext AppContext
        {
            get { return _dbContext as OzelDersContext; }
        }

        public async Task ChangeDateAsync(CartItem cartItem)
        {
            AppContext.CartItems.Update(cartItem);
            await AppContext.SaveChangesAsync();
        }

        public void ClearCart(int cartId)
        {
            AppContext
                .CartItems
                .Where(ci => ci.CartId == cartId)
                .ExecuteDelete();
        }
    }
}