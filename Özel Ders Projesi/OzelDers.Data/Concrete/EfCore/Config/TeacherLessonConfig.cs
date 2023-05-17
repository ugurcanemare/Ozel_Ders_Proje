using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Concrete.EfCore.Config
{
    public class TeacherLessonConfig : IEntityTypeConfiguration<TeacherLesson>
    {
        public void Configure(EntityTypeBuilder<TeacherLesson> builder)
        {
            builder.HasKey(lc => new { lc.LessonId , lc.TeacherId });
        }
    }
}