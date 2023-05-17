using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Data.Concrete.EfCore.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            //Şu kullanıcının kartını oluştur
            #region Rol Bilgileri
            List<Role> roles = new List<Role>
            {
                new Role{Name="Admin", Description="Yöneticiler", NormalizedName="ADMIN"},
                new Role{Name="Teacher", Description="Öğretmenler", NormalizedName="TEACHER"},
                new Role{Name="Student", Description="Öğrenciler", NormalizedName="STUDENT"}
            };
            modelBuilder.Entity<Role>().HasData(roles);
            #endregion
            #region Kullanıcı Bilgileri
            List<User> users = new List<User>
            {
                new User{FirstName="Uğurcan", LastName="Emare", UserName="ugurcan", NormalizedUserName="UGURCAN", Email="ugurcan@gmail.com", NormalizedEmail="UGURCAN@GMAIL.COM", Gender="Erkek", DateOfBirth=new DateTime(1999,11,6), City="Beşiktaş", Town="İstanbul", EmailConfirmed=true},
            };

            modelBuilder.Entity<User>().HasData(users);
            #endregion
            #region Parola İşlemleri
            var passwordHasher = new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            #endregion
            
            #region Rol Atama İşlemleri
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>{ UserId=users[0].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="Admin").Id},
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion
            List<Cart> carts = new List<Cart>
            {
                new Cart{Id=1, UserId=users[0].Id}
            };
            modelBuilder.Entity<Cart>().HasData(carts);
        }
    }
}