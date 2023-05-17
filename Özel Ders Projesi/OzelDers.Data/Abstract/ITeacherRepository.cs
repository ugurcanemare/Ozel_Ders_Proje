using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;

namespace OzelDers.Data.Abstract
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
        Task<List<Teacher>> GetAllTeachersFullDataAsync(bool ApprovedStatus, string categoryurl);
        Task<List<Teacher>> GetTeacherAsync();
        Task CreateUser(User user,Teacher teacher,int[] SelectedLessons,int[] SelectedCategories);
        Task UpdateUser(User user,int[] SelectedLessons,int[] SelectedCategories);
        Task<Teacher> GetTeacherByUserNameAsync(string userName);

    }
}