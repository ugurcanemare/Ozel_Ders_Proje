using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OzelDers.Entity.Concrete;

namespace OzelDers.MVC.Models.ViewModels.AccountModel.Teachers
{
    public class TeacherManageViewModel
    {
        public string Id { get; set; }
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
        [DisplayName("İlçe")]
        public string Town { get; set; }

        [DisplayName("Eposta")]
        [Required(ErrorMessage = "Eposta alanı zorunludur")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DisplayName("Telefon Numarası")]
        public string PhoneNumber { get; set; }
        [DisplayName("Şehir")]
        public string City { get; set; }
        [DisplayName("Resim")]
        public string Img { get; set; }
        public IFormFile Image { get; set; }
        [DisplayName("Mezun Olduğu Okul")]
        public string School { get; set; }
        [DisplayName("Mezun Olduğu Bölüm")]
        public string Department { get; set; }
        [DisplayName("Ders Saati Ücreti")]
        [Required(ErrorMessage = "Ders saati ücreti zorunludur.")]
        public decimal? LessonPrice { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<Category> Categories { get; set; }

        [DisplayName("Parola")]
        [Required(ErrorMessage = "Parola alanı zorunludur")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Parola Tekrar")]
        [Required(ErrorMessage = "Parola tekrar alanı zorunludur")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "İki parola aynı olmalıdır!")]
        public string RePassword { get; set; }
        public int[] SelectedLessons { get; set; }
        public int[] SelectedCategories{ get; set; }
    }
}