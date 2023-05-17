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
    public class StudentManager : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentManager(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Task CreateAsync(Student student)
        {
            throw new NotImplementedException();
        }

        public async Task CreateUser(User user,Student student)
        {
            await _studentRepository.CreateUser(user,student);
        }

        public void Delete(Student student)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Student> GetStudentByUserId(string id)
        {
           return await _studentRepository.GetStudentByUserId(id);
        }

        public void Update(Student student)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUser(User user, int[] SelectedCategories, int[] SelectedClasses)
        {
            await _studentRepository.UpdateUser(user, SelectedCategories, SelectedClasses);
        }
    }
}