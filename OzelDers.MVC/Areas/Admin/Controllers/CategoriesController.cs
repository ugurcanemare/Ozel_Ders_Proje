using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OzelDers.Business.Abstract;
using OzelDers.Core;
using OzelDers.Entity.Concrete;
using OzelDers.MVC.Areas.Admin.Models.ViewModels;

namespace OzelDers.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class CategoriesController : Controller
    {
        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #region Listeleme
        public async Task<IActionResult> Index(CategoryListViewModel categoryListViewModel)
        {
            List<Category> categoryList = await _categoryService.GetCategoriesAsync(categoryListViewModel.ApprovedStatus);
            List<CategoryViewModel> categories = new List<CategoryViewModel>();
            foreach (var category in categoryList)
            {
                categories.Add(new CategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    IsApproved = category.IsApproved,
                    Url = category.Url,
                });
            }
            categoryListViewModel.Categories = categories;

            return View(categoryListViewModel);
        }

        #endregion
        #region Yeni Kayıt
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryAddViewModel categoryAddViewModel)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category
                {
                    Name = categoryAddViewModel.Name,
                    Url = Jobs.GetUrl(categoryAddViewModel.Name),
                    IsApproved = categoryAddViewModel.IsApproved,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };
                await _categoryService.CreateAsync(category);
                return RedirectToAction("Index");
            }
            return View(categoryAddViewModel);
        }

        #endregion
        #region Kayıt Güncelleme
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Category category = await _categoryService.GetByIdAsync(id);
            CategoryUpdateViewModel categoryUpdateViewModel = new CategoryUpdateViewModel()
            {
                Id = category.Id,
                Name = category.Name,
                Url = category.Url,
                ModifiedDate = category.ModifiedDate,
                IsApproved = category.IsApproved
            };

            return View(categoryUpdateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryUpdateViewModel categoryUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                Category category = await _categoryService.GetByIdAsync(categoryUpdateViewModel.Id);
                category.Name = categoryUpdateViewModel.Name;
                category.Url = Jobs.GetUrl(categoryUpdateViewModel.Name);
                category.IsApproved = categoryUpdateViewModel.IsApproved;
                category.ModifiedDate = DateTime.Now;
                _categoryService.Update(category);

                return RedirectToAction("Index");
            }
            return View(categoryUpdateViewModel);
        }

        #endregion
        #region Kayıt Silme
        public async Task<IActionResult> Delete(int id)
        {
            Category deletedCategory = await _categoryService.GetByIdAsync(id);
            if (deletedCategory != null)
            {
                _categoryService.Delete(deletedCategory);
            }

            return RedirectToAction("Index");
        }

        #endregion
        #region Onaylı
        public async Task<IActionResult> UpdateIsApproved(int id, bool ApprovedStatus)
        {
            Category category = await _categoryService.GetByIdAsync(id);
            if (category != null)
            {
                category.IsApproved = !category.IsApproved;
                _categoryService.Update(category);
            }
            CategoryListViewModel categoryListViewModel = new CategoryListViewModel
            {
                ApprovedStatus = ApprovedStatus
            };
            return RedirectToAction("Index", categoryListViewModel);
        }
        #endregion
    }
}
