using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Concrete.EfCore.Config
{
    public class TeacherCategoryConfig : IEntityTypeConfiguration<TeacherCategory>
    {
        public void Configure(EntityTypeBuilder<TeacherCategory> builder)
        {
           builder.HasKey(lc => new { lc.CategoryId , lc.TeacherId });
        }
    }
}