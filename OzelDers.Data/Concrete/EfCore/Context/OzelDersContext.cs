using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApp.Data.Concrete.EfCore.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OzelDers.Data.Concrete.EfCore.Config;
using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;

namespace OzelDers.Data.Concrete.EfCore.Context
{
    public class OzelDersContext : IdentityDbContext<User, Role, string>
    {
        public OzelDersContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<TeacherLesson> TeacherLessons { get; set; }
        public DbSet<TeacherCategory> TeacherCategories { get; set; }
        public DbSet<StudentCategory> StudentCategories { get; set; }
        public DbSet<LessonClass> LessonClasses { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<LessonCategory> LessonCategories { get; set; }
        public DbSet<LessonClassCategory> LessonClassCategories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.SeedData();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfig).Assembly);
        base.OnModelCreating(modelBuilder);
        }
    }
}
