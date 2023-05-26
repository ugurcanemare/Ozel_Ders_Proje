using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDers.Business.Abstract;
using OzelDers.Entity.Concrete;

namespace OzelDers.Business.Concrete
{
    public class ImageManager : IImageService
    {
        public Task CreateAsync(Image image)
        {
            throw new NotImplementedException();
        }

        public void Delete(Image image)
        {
            throw new NotImplementedException();
        }

        public Task<List<Image>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Image> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public int ImageCount(string userId)
        {
            throw new NotImplementedException();
        }

        public void Update(Image image)
        {
            throw new NotImplementedException();
        }
    }
}