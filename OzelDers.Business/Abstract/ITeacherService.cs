using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;

namespace OzelDers.Business.Abstract
{
    public interface ITeacherService
    {
        Task CreateAsync(Teacher teacher);
        Task<User> GetByIdAsync(int id);
        Task<List<Teacher>> GetAllAsync();
        void Update(Teacher teacher);
        void Delete(Teacher teacher);
        Task CreateUser(User user,Teacher teacher,int[] SelectedLessons,int[] SelectedCategories);
        Task UpdateUser(User user,int[] SelectedLessons,int[] SelectedCategories);
        Task<List<Teacher>> GetAllTeachersFullDataAsync(bool ApprovedStatus, string categoryurl);
        Task<List<Teacher>> GetTeacherAsync();
        Task<Teacher> GetTeacherByUserNameAsync(string userName);

    }
}