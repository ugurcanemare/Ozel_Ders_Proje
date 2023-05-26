using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDers.Entity.Concrete;

namespace OzelDers.Business.Abstract
{
    public interface IImageService
    {
        Task CreateAsync(Image image);
        Task<Image> GetByIdAsync(int id);
        Task<List<Image>> GetAllAsync();
        void Update(Image image);
        void Delete(Image image);
        int ImageCount(string userId);
    }
}