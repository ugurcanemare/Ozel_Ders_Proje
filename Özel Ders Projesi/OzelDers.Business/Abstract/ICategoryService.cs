using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDers.Entity.Concrete;

namespace OzelDers.Business.Abstract
{
    public interface ICategoryService
    {
        Task CreateAsync(Category category);
        Task<Category> GetByIdAsync(int id);
        Task<List<Category>> GetAllAsync();
        void Update(Category category);
        void Delete(Category category);
        Task<List<Category>> GetCategoriesAsync(bool ApprovedStatus);
        Task<string> GetCategoryNameByUrlAsync(string url);
    }
}