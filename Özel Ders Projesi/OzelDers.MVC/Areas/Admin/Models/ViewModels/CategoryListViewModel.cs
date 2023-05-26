using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzelDers.MVC.Areas.Admin.Models.ViewModels
{
    public class CategoryListViewModel
    {
         public List<CategoryViewModel> Categories { get; set; }
        public bool ApprovedStatus { get; set; } = true;
    }
}