using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Concrete.EfCore.Config
{
    public class StudentCategoryConfig : IEntityTypeConfiguration<StudentCategory>
    {
        public void Configure(EntityTypeBuilder<StudentCategory> builder)
        {
            builder.HasKey(sc => new { sc.CategoryId, sc.StudentId});
        }
    }
}