using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OzelDers.MVC.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        [DisplayName("Ad")]
        [Required(ErrorMessage ="Ad alanı boş bırakılmamalıdır.")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "Soyad alanı boş bırakılmamalıdır.")]
        public string LastName { get; set; }

        [DisplayName("İlçe")]
        [Required(ErrorMessage = "İlçe alanı boş bırakılmamalıdır.")]
        public string Town { get; set; }

        [DisplayName("Şehir")]
        [Required(ErrorMessage = "Şehir alanı boş bırakılmamalıdır.")]
        public string City { get; set; }

        [DisplayName("Telefon Numarası")]
        [Required(ErrorMessage = "Telefon numarası alanı boş bırakılmamalıdır.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DisplayName("Eposta")]
        [Required(ErrorMessage = "Eposta alanı boş bırakılmamalıdır.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime OrderDate { get; set; }
        public CartViewModel Cart { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }


        //Kredi Kartı ile ilgili properties
        [DisplayName("Kartın Üzerinde Ad Soyad")]
        [Required(ErrorMessage ="Ad soyad zorunludur")]
        public string CardName { get; set; }

        [DisplayName("Kart Numarası")]
        [Required(ErrorMessage = "Ad soyad zorunludur")]
        public string CardNumber { get; set; }

        [DisplayName("Geçerlilik Tarihi Yıl")]
        [Required(ErrorMessage = "Yıl bilgisi zorunludur")]
        public string ExpirationYear { get; set; }
        [DisplayName("Geçerlilik Tarihi Ay")]
        [Required(ErrorMessage = "Ay bilgisi zorunludur")]
        public string ExpirationMonth { get; set; }

        [DisplayName("Cvc No")]
        [Required(ErrorMessage = "Cvc bilgisi zorunludur")]
        public string Cvc { get; set; }
    }
}