using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Concrete.EfCore.Config
{
    public class StudentClassConfig : IEntityTypeConfiguration<StudentClass>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<StudentClass> builder)
        {
            builder.HasKey(sc => new { sc.ClassId, sc.StudentId});
        }
    }
}