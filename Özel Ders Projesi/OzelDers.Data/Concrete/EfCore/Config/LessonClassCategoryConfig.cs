using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Concrete.EfCore.Config
{
    public class LessonClassCategoryConfig : IEntityTypeConfiguration<LessonClassCategory>
    {
        public void Configure(EntityTypeBuilder<LessonClassCategory> builder)
        {
            builder.HasKey(lc => new { lc.LessonClassId, lc.CategoryId });
            builder.HasData(
                new { LessonClassId = 1, CategoryId = 1 },
                new { LessonClassId = 2, CategoryId = 1 },
                new { LessonClassId = 3, CategoryId = 1 },
                new { LessonClassId = 4, CategoryId = 1 },

                new { LessonClassId = 5, CategoryId = 2 },
                new { LessonClassId = 6, CategoryId = 2 },
                new { LessonClassId = 7, CategoryId = 2 },
                new { LessonClassId = 8, CategoryId = 2 },

                new { LessonClassId = 9, CategoryId = 3 },
                new { LessonClassId = 10, CategoryId = 3 },
                new { LessonClassId = 11, CategoryId = 3 },
                new { LessonClassId = 12, CategoryId = 3 }
            );
        }
    }
}