using System;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualGallery.ViewModel;

namespace VirtualGallery.BusinessInterface
{
    public interface ICategoryService
    {
        // Operación para obtener todas las categorías
        Task<IEnumerable<CategoryViewModel>> GetAllCategories();

        // Operación para obtener una categoría por su ID
        Task<CategoryViewModel> GetCategoryById(int categoryId);

        // Operación para crear una nueva categoría
        Task<CategoryViewModel> CreateCategory(CategoryViewModel category);

        // Operación para actualizar una categoría existente
        Task<CategoryViewModel> UpdateCategory(int categoryId, CategoryViewModel category);

        // Operación para eliminar una categoría por su ID
        Task<bool> DeleteCategory(int categoryId);
    }
}
