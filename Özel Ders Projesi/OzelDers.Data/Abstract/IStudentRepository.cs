using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;

namespace OzelDers.Data.Abstract
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task CreateUser(User user,Student student);
        Task UpdateUser(User user,int[] SelectedCategories,int[] SelectedClasses);
        Task<Student> GetStudentByUserId(string id);
    }
}