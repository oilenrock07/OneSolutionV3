using OneSolutionV3.Infrastructure;
using OneSolutionV3.Domain.Models;
using System.Collections.Generic;
using OneSolutionV3.Domain.DTO.Category;

namespace OneSolutionV3.Service.Interface
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
        IEnumerable<Category> GetCategoriesByUserId(int userId);
        IEnumerable<CategoryViewModel> GetCategoryIdAndNameByUserId(int userId);
        IEnumerable<string> GetCategoryNames(int userId);
        IEnumerable<CategoryViewModel> GetCategoryNames(int userId,IEnumerable<string> categoryNames);
        bool CategoryNameExists(int userId, int categoryId, string categoryName);
    }
}
