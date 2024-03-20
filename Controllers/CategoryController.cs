using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VirtualGallery.BusinessInterface;
using VirtualGallery.Services;
using VirtualGallery.ViewModel;

namespace VirtualGallery.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategories();
            return View(categories);
        }

        public async Task<IActionResult> Details(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.CreateCategory(categoryViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(categoryViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryViewModel categoryViewModel)
        {
            if (id != categoryViewModel.ID)
                return NotFound();

            if (ModelState.IsValid)
            {
                var updatedCategory = await _categoryService.UpdateCategory(id, categoryViewModel);
                if (updatedCategory == null)
                    return NotFound();

                return RedirectToAction(nameof(Index));
            }
            return View(categoryViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _categoryService.DeleteCategory(id);
            if (!result)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
