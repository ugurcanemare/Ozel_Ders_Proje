using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Abstract
{
    public interface IImageRepository : IGenericRepository<Image>
    {
        int ImageCount (string userId);
    }
}