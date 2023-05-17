using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OzelDers.MVC.Models.ViewModels.AccountModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Kullanıcı adı boş bırakılmamalıdır")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Parola boş bırakılmamalıdır")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}