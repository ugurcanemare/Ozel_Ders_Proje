using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OzelDers.Data.Abstract;
using OzelDers.Data.Concrete.EfCore.Context;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Concrete.EfCore
{
    public class EfCoreLessonRepository : EfCoreGenericRepository<Lesson>, ILessonRepository
    {
        public EfCoreLessonRepository(OzelDersContext _appContext) : base(_appContext)
        {
        }

        OzelDersContext AppContext
        {
            get { return _dbContext as OzelDersContext; }
        }
        public async Task CreateLesson(Lesson lesson,int[] SelectedCategories)
        {
            await AppContext.Lessons.AddAsync(lesson);
            await AppContext.SaveChangesAsync();
            List<LessonCategory> lessonCategories = new List<LessonCategory>();
            foreach (var categoryId in SelectedCategories)
            {
                lessonCategories.Add(new LessonCategory {
                    CategoryId = categoryId,
                    LessonId = lesson.Id
                });
            }
            AppContext.LessonCategories.AddRange(lessonCategories);
            await AppContext.SaveChangesAsync();
        }

        public async Task<Lesson> GetAllLessonDataAsync(int id)
        {
            var lesson = await AppContext
                                .Lessons
                                .Where(l => l.Id == id)
                                .Include(l => l.LessonCategories)
                                .ThenInclude(lc => lc.Category)
                                .FirstOrDefaultAsync();
            return lesson;
        }

        public Task<List<Lesson>> GetAllLessonsFullDataAsync(bool ApprovedStatus, string categoryurl)
        {
            throw new NotImplementedException();
        }

        public Task UpdateLesson(Lesson Lesson, int[] SelectedCategories)
        {
            throw new NotImplementedException();
        }
    }
}