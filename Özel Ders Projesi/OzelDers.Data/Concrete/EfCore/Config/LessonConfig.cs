using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Concrete.EfCore.Config
{
    public class LessonConfig : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.HasData(
                new Lesson { Id = 1, Name = "Matematik", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "matematik" },
                new Lesson { Id = 2, Name = "Fizik", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "fizik" },
                new Lesson { Id = 3, Name = "Kimya", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "kimya" },
                new Lesson { Id = 4, Name = "Biyoloji", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "biyoloji" },
                new Lesson { Id = 5, Name = "Hayat Bilgisi", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "hayat-bilgisi" },
                new Lesson { Id = 6, Name = "Sosyal Bilgiler", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "sosyal-bilgiler" },
                new Lesson { Id = 7, Name = "İnkılap Tarihi", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "inkilap-tarihi" },
                new Lesson { Id = 8, Name = "Felsefe", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "felsefe" },
                new Lesson { Id = 9, Name = "Din Kültürü ve Ahlak Bilgisi", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, Url = "din-bilgisi-ve-ahlak-bilgisi" }
            );

        }
    }
}