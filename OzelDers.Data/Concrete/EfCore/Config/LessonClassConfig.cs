using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Concrete.EfCore.Config
{
    public class LessonClassConfig : IEntityTypeConfiguration<LessonClass>
    {
        public void Configure(EntityTypeBuilder<LessonClass> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.HasData(
                new LessonClass { Id = 1, Name = "1. Sınıf", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "1-sınıf" },
                new LessonClass { Id = 2, Name = "2. Sınıf", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "2-sınıf" },
                new LessonClass { Id = 3, Name = "3. Sınıf", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "3-sınıf" },
                new LessonClass { Id = 4, Name = "4. Sınıf", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "4-sınıf" },
                new LessonClass { Id = 5, Name = "5. Sınıf", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "5-sınıf" },
                new LessonClass { Id = 6, Name = "6. Sınıf", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "6-sınıf" },
                new LessonClass { Id = 7, Name = "7. Sınıf", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "7-sınıf" },
                new LessonClass { Id = 8, Name = "8. Sınıf", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "8-sınıf" },
                new LessonClass { Id = 9, Name = "9. Sınıf", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "9-sınıf" },
                new LessonClass { Id = 10, Name = "10. Sınıf", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "10-sınıf" },
                new LessonClass { Id = 11, Name = "11. Sınıf", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "11-sınıf" },
                new LessonClass { Id = 12, Name = "12. Sınıf", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "12-sınıf" }
                );
        }
    }
}