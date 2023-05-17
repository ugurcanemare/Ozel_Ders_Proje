using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDers.Entity.Concrete;

namespace OzelDers.Business.Abstract
{
    public interface ILessonService
    {
        Task CreateAsync(Lesson lesson);
        Task<Lesson> GetByIdAsync(int id);
        Task<List<Lesson>> GetAllAsync();
        void Update(Lesson lesson);
        void Delete(Lesson lesson);
        Task<List<Lesson>> GetAllLessonsFullDataAsync(bool ApprovedStatus, string categoryurl=null);
        Task<Lesson> GetAllLessonDataAsync(int id);
        Task CreateLesson(Lesson lesson, int[] SelectedCategories);
        Task UpdateLesson(Lesson lesson, int[] SelectedCategories);
    }
}