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
    public class EfCoreLessonClassRepository : EfCoreGenericRepository<LessonClass>, ILessonClassRepository
    {
        public EfCoreLessonClassRepository(OzelDersContext _appContext) : base(_appContext)
        {
        }
        OzelDersContext AppContext
        {
            get { return _dbContext as OzelDersContext; }
        }
    }
}