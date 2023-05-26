using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDers.Business.Abstract;
using OzelDers.Data.Abstract;
using OzelDers.Entity.Concrete;

namespace OzelDers.Business.Concrete
{
    public class LessonClassManager : ILessonClassService
    {
        private readonly ILessonClassRepository _lessonsClassRepository;

        public LessonClassManager(ILessonClassRepository lessonsClassRepository)
        {
            _lessonsClassRepository = lessonsClassRepository;
        }

        public Task CreateAsync(LessonClass lessonClass)
        {
            throw new NotImplementedException();
        }

        public void Delete(LessonClass lessonClass)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LessonClass>> GetAllAsync()
        {
            return await _lessonsClassRepository.GetAllAsync();
        }

        public Task<LessonClass> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(LessonClass lessonClass)
        {
            throw new NotImplementedException();
        }
    }
}