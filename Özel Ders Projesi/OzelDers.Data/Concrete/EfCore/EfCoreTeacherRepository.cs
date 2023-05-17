using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OzelDers.Data.Abstract;
using OzelDers.Data.Concrete.EfCore.Context;
using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;

namespace OzelDers.Data.Concrete.EfCore
{
    public class EfCoreTeacherRepository : EfCoreGenericRepository<Teacher>, ITeacherRepository
    {
        public EfCoreTeacherRepository(OzelDersContext _appContext) : base(_appContext)
        {
        }
         OzelDersContext AppContext
        {
            get { return _dbContext as OzelDersContext; }
        }
        public async Task<List<Teacher>> GetTeacherAsync()
        {
              var users = AppContext
                            .Teachers
                            .Include(t => t.User)
                            .ThenInclude(u => u.Image)
                            .Include(t => t.TeacherLesson)
                            .ThenInclude(tl => tl.Lesson)
                            .Include(t => t.TeacherCategory)
                            .ThenInclude(tc => tc.Category)
                            .Take(8)
                            .AsQueryable();

             return await users.ToListAsync();
        }
        public async Task CreateUser(User user,Teacher teacher,int[] SelectedLessons,int[] SelectedCategories)
        {
            await AppContext.Teachers.AddAsync(teacher);
            await AppContext.SaveChangesAsync();
            List<TeacherLesson> teacherLessons = new List<TeacherLesson>();
            foreach (var lessonId in SelectedLessons)
            {
                teacherLessons.Add( new TeacherLesson 
                {
                    LessonId = lessonId,
                    TeacherId = teacher.Id
                });
            }
            AppContext.TeacherLessons.AddRange(teacherLessons);
            List<TeacherCategory> teacherCategories = new List<TeacherCategory>();
            foreach (var categoryId in SelectedCategories)
            {
                teacherCategories.Add( new TeacherCategory 
                {
                    CategoryId = categoryId,
                    TeacherId = teacher.Id
                });
            }
            AppContext.TeacherCategories.AddRange(teacherCategories);
            user.Image.UserId = user.Id;
            await AppContext.SaveChangesAsync();
        }

        public async Task<List<Teacher>> GetAllTeachersFullDataAsync(bool ApprovedStatus, string categoryurl)
        {
            var users = AppContext
                            .Teachers
                            .Include(t => t.User)
                            .ThenInclude(u => u.Image)
                            .Include(t => t.TeacherLesson)
                            .ThenInclude(tl => tl.Lesson)
                            .Include(t => t.TeacherCategory)
                            .ThenInclude(tc => tc.Category)
                            .AsQueryable();
            if (categoryurl != null)
            {
                users = users
                    .Where(b => b.TeacherCategory.Any(tc => tc.Category.Url == categoryurl));
            }

            return await users
                        .ToListAsync();
        }

        public async Task UpdateUser(User user, int[] SelectedLessons, int[] SelectedCategories)
        {
            Teacher teacher = await AppContext
            .Teachers
            .Include(t=>t.User)
            .Where(x=>x.UserId == user.Id)
            .Include(t => t.TeacherCategory)
            .Include(t => t.TeacherLesson)
            .FirstOrDefaultAsync();
            teacher.TeacherLesson = SelectedLessons.Select(sc => new TeacherLesson
            {
                LessonId = sc,
                TeacherId = teacher.Id
            }).ToList();
            teacher.TeacherCategory = SelectedCategories.Select(sl => new TeacherCategory
            {
                CategoryId = sl,
                TeacherId = teacher.Id
            }).ToList();
             AppContext.Update(teacher);
            await AppContext.SaveChangesAsync();
        }
        public async Task<Teacher> GetTeacherByUserNameAsync(string userName)
        {
            var user = await AppContext.Teachers.Include(t => t.User).ThenInclude(u => u.Image).Where(x => x.User.UserName == userName).FirstOrDefaultAsync();
            return user;
        }
    }
    }