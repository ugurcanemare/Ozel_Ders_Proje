using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OzelDers.Data.Abstract;
using OzelDers.Data.Concrete.EfCore.Context;
using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;

namespace OzelDers.Data.Concrete.EfCore
{
    public class EfCoreStudentRepository : EfCoreGenericRepository<Student>, IStudentRepository
    {
        public EfCoreStudentRepository(OzelDersContext _appContext) : base(_appContext)
        {
        }
         OzelDersContext AppContext
        {
            get { return _dbContext as OzelDersContext; }
        }

        public async Task CreateUser(User user,Student student)
        {
            await AppContext.Students.AddAsync(student);
            await AppContext.SaveChangesAsync();
            user.Image.UserId = user.Id;
            await AppContext.SaveChangesAsync();
        }

        public async Task<Student> GetStudentByUserId(string id)
        {
           return await AppContext.Students.Where(x => x.UserId == id).FirstOrDefaultAsync();
            
        }

        public Task UpdateUser(User user, int[] SelectedCategories, int[] SelectedClasses)
        {
            throw new NotImplementedException();
        }
    }
}