using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;

namespace OzelDers.Business.Abstract
{
    public interface IStudentService
    {
        Task CreateAsync(Student student);
        Task<User> GetByIdAsync(int id);
        Task<List<Student>> GetAllAsync();
        void Update(Student student);
        void Delete(Student student);
        Task CreateUser(User user, Student student);
        Task UpdateUser(User user,int[] SelectedCategories, int[] SelectedClasses);
        Task<Student> GetStudentByUserId(string id);

    }
}