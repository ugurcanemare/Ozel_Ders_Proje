using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDers.Business.Abstract;
using OzelDers.Data.Abstract;
using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;

namespace OzelDers.Business.Concrete
{
    public class TeacherManager : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherManager(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public Task CreateAsync(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public async Task CreateUser(User user,Teacher teacher,int[] SelectedLessons,int[] SelectedCategories)
        {
            await _teacherRepository.CreateUser(user,teacher,SelectedLessons,SelectedCategories);
        }

        public void Delete(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _teacherRepository.GetAllAsync();
        }

        public async Task<List<Teacher>> GetAllTeachersFullDataAsync(bool ApprovedStatus, string categoryurl)
        {
            return await _teacherRepository.GetAllTeachersFullDataAsync(ApprovedStatus,categoryurl);
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Teacher>> GetTeacherAsync()
        {
           return await _teacherRepository.GetTeacherAsync();
        }

        public async Task<Teacher> GetTeacherByUserNameAsync(string userName)
        {
           return await _teacherRepository.GetTeacherByUserNameAsync(userName);
        }

        public void Update(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUser(User user, int[] SelectedLessons, int[] SelectedCategories)
        {
            await _teacherRepository.UpdateUser(user, SelectedLessons, SelectedCategories);
        }
    }
}