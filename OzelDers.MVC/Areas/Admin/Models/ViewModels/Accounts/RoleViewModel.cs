using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OzelDers.MVC.Areas.Admin.Models.ViewModels.Accounts
{
    public class RoleViewModel
    {
         public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}