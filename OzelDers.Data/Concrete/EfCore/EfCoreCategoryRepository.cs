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
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(OzelDersContext _appContext) : base(_appContext)
        {
        }

        OzelDersContext AppContext
        {
            get { return _dbContext as OzelDersContext; }
        }
        public async Task<List<Category>> GetCategoriesAsync(bool ApprovedStatus)
        {
            return await AppContext
               .Categories
               .Where(c => c.IsApproved == ApprovedStatus)
               .ToListAsync();            
        }

        public async Task<string> GetCategoryNameByUrlAsync(string categoryurl=null)
        {
            Category category = await AppContext
               .Categories
               .Where(c => c.Url == categoryurl)
               .FirstOrDefaultAsync();
            return category.Name;
        }
    }
}