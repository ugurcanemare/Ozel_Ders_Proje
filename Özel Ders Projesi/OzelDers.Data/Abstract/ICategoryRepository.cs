using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Abstract
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<List<Category>> GetCategoriesAsync(bool ApprovedStatus);
        Task<string> GetCategoryNameByUrlAsync(string url);
    }
}