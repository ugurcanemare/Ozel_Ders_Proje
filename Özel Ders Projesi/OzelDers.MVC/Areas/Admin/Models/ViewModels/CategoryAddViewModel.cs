using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OzelDers.MVC.Areas.Admin.Models.ViewModels
{
    public class CategoryAddViewModel
    {
        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage = "Kategori adı boş bırakılmamalıdır")]
        [MinLength(5, ErrorMessage = "Kategori adı en az 5 karakter olmalıdır")]
        [MaxLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter olmalıdır")]
        public string Name { get; set; }

        public string Url { get; set; }

        [DisplayName("Onaylı mı?")]
        public bool IsApproved { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}