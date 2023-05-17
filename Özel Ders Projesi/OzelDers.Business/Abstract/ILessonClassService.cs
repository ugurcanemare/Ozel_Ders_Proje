using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDers.Entity.Concrete;

namespace OzelDers.Business.Abstract
{
    public interface ILessonClassService
    {
        
        Task CreateAsync(LessonClass lessonClass);
        Task<LessonClass> GetByIdAsync(int id);
        Task<List<LessonClass>> GetAllAsync();
        void Update(LessonClass lessonClass);
        void Delete(LessonClass lessonClass);
    }
}