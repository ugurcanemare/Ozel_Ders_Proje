using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDers.Business.Abstract;
using OzelDers.Data.Abstract;
using OzelDers.Entity.Concrete;

namespace OzelDers.Business.Concrete
{
    public class LessonManager : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonManager(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task CreateAsync(Lesson lesson)
        {
            await _lessonRepository.CreateAsync(lesson);
        }

        public async Task CreateLesson(Lesson lesson, int[] SelectedCategories)
        {
            await _lessonRepository.CreateLesson(lesson, SelectedCategories);
        }

        public void Delete(Lesson lesson)
        {
            _lessonRepository.Delete(lesson);
        }

        public async Task<List<Lesson>> GetAllAsync()
        {
            return await _lessonRepository.GetAllAsync();
        }

        public async Task<Lesson> GetAllLessonDataAsync(int id)
        {
            return await _lessonRepository.GetAllLessonDataAsync(id);
        }

        public async Task<List<Lesson>> GetAllLessonsFullDataAsync(bool ApprovedStatus, string categoryurl=null)
        {
            return await _lessonRepository.GetAllLessonsFullDataAsync(ApprovedStatus, categoryurl);
        }

        public async Task<Lesson> GetByIdAsync(int id)
        {
            return await _lessonRepository.GetByIdAsync(id);
        }

        public void Update(Lesson lesson)
        {
            _lessonRepository.Update(lesson);
        }

        public async Task UpdateLesson(Lesson lesson ,int[] SelectedCategories)
        {
            await _lessonRepository.UpdateLesson(lesson,SelectedCategories);
        }
    }
}