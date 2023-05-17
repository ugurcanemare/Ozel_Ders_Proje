using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OzelDers.Business.Abstract;
using OzelDers.Data.Concrete.EfCore;
using OzelDers.Entity.Concrete;
using OzelDers.MVC.Models.ViewModels;

namespace OzelDers.MVC.ViewComponents
{
  public class CategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoriesViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> categories = await _categoryService.GetAllAsync();
            List<CategoryViewModel> categoryViewModel = new List<CategoryViewModel>();
            foreach (Category category in categories)
            {
                categoryViewModel.Add(new CategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    Url = category.Url
                });
            }
            if (RouteData.Values["categoryurl"] != null)
            {
                ViewBag.SelectedCategory = RouteData.Values["categoryurl"];
            }
            return View(categoryViewModel);
        }
    }
}