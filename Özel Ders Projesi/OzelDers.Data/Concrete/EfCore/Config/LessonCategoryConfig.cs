using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Concrete.EfCore.Config
{
    public class LessonCategoryConfig : IEntityTypeConfiguration<LessonCategory>
    {
        public void Configure(EntityTypeBuilder<LessonCategory> builder)
        {
            builder.HasKey(lc => new { lc.LessonId, lc.CategoryId });
            builder.HasData(
                new LessonCategory { LessonId = 1, CategoryId = 1 },
                new LessonCategory { LessonId = 1, CategoryId = 2 },
                new LessonCategory { LessonId = 1, CategoryId = 3 },
                new LessonCategory { LessonId = 1, CategoryId = 4 },

                new LessonCategory { LessonId = 2, CategoryId = 3 },
                new LessonCategory { LessonId = 2, CategoryId = 4 },

                new LessonCategory { LessonId = 3, CategoryId = 3 },
                new LessonCategory { LessonId = 3, CategoryId = 4 },

                new LessonCategory { LessonId = 4, CategoryId = 3 },
                new LessonCategory { LessonId = 4, CategoryId = 4 },

                new LessonCategory { LessonId = 5, CategoryId = 1 },
                new LessonCategory { LessonId = 5, CategoryId = 2 },

                new LessonCategory { LessonId = 6, CategoryId = 2 },
                new LessonCategory { LessonId = 6, CategoryId = 3 },

                new LessonCategory { LessonId = 7, CategoryId = 2 },
                new LessonCategory { LessonId = 7, CategoryId = 3 },

                new LessonCategory { LessonId = 8, CategoryId = 3 },

                new LessonCategory { LessonId = 9, CategoryId = 1 },
                new LessonCategory { LessonId = 9, CategoryId = 2 },
                new LessonCategory { LessonId = 9, CategoryId = 3 }

            );
        }
    }
}