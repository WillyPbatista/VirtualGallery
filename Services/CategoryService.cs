using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VirtualGallery.BusinessInterface;
using VirtualGallery.Data;
using VirtualGallery.Models;
using VirtualGallery.ViewModel;

namespace VirtualGallery.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryViewModel> CreateCategory(CategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return _mapper.Map<CategoryViewModel>(category);
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category == null)
                return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
        }

        public async Task<CategoryViewModel> GetCategoryById(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            return _mapper.Map<CategoryViewModel>(category);
        }

        public async Task<CategoryViewModel> UpdateCategory(int categoryId, CategoryViewModel categoryViewModel)
        {
            var existingCategory = await _context.Categories.FindAsync(categoryId);
            if (existingCategory == null)
                return null;

            _mapper.Map(categoryViewModel, existingCategory);

            await _context.SaveChangesAsync();
            return categoryViewModel;
        }
    }
}
