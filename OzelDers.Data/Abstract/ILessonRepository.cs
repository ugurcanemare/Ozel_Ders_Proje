using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Abstract
{
    public interface ILessonRepository : IGenericRepository<Lesson>
    {
        Task<List<Lesson>> GetAllLessonsFullDataAsync (bool ApprovedStatus, string categoryurl);
        Task<Lesson> GetAllLessonDataAsync(int id);
        Task CreateLesson(Lesson lesson,int[] SelectedCategories);
        Task UpdateLesson(Lesson lesson, int[] SelectedCategories);
    }
}