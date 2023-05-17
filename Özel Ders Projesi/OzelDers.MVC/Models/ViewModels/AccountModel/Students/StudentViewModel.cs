using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using OzelDers.Entity.Concrete;

namespace OzelDers.MVC.Models.ViewModels.AccountModel.Students
{
    public class StudentViewModel
    {

        [DisplayName("Ad")]
        [Required(ErrorMessage = "Ad alanı zorunludur")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "Soyad alanı zorunludur")]
        public string LastName { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı alanı zorunludur")]
        public string UserName { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        [DisplayName("Cinsiyet")]
        public string Gender { get; set; }
        public string Url { get; set; }
        [DisplayName("Doğum Tarihi")]
        public DateTime? DateOfBirth { get; set; }
        public string Town { get; set; }

        [DisplayName("Eposta")]
        [Required(ErrorMessage = "Eposta alanı zorunludur")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DisplayName("Telefon Numarası")]
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        [DisplayName("Resim")]
        public IFormFile Image { get; set; }
        [DisplayName("Okuduğu Okul")]
        public string School { get; set; }

        [DisplayName("Parola")]
        [Required(ErrorMessage = "Parola alanı zorunludur")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Parola Tekrar")]
        [Required(ErrorMessage = "Parola tekrar alanı zorunludur")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "İki parola aynı olmalıdır!")]
        public string RePassword { get; set; }
        public string LessonClass{ get; set; }
        public string Category { get; set; }
    }
}