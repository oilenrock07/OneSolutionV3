using System.Collections.Generic;
using OneSolutionV3.Infrastructure;
using OneSolutionV3.Domain.Models;
using OneSolutionV3.Service.Interface;
using OneSolutionV3.Domain.DTO.Category;
using System.Linq;

namespace OneSolutionV3.Service.Repository
{
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository 
    {

        public CategoryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public IEnumerable<Category> GetCategoriesByUserId(int userId)
        {
            return this.Find(e => e.UserId == userId && !e.IsDeleted);
        }


        public IEnumerable<CategoryViewModel> GetCategoryIdAndNameByUserId(int userId)
        {
            var result = base._context.Categories.Where(e => e.UserId == userId && !e.IsDeleted)
                         .Select(e => new CategoryViewModel
                         {
                             CategoryId = e.CategoryId,
                             CategoryName = e.CategoryName,
                             IsExpense = e.IsExpense
                         });
            return result;
        }


        public IEnumerable<string> GetCategoryNames(int userId)
        {
            return _dbSet.Where(e => e.UserId == userId && !e.IsDeleted)
                   .Select(e => e.CategoryName);
        }

        public IEnumerable<CategoryViewModel> GetCategoryNames(int userId,IEnumerable<string> categoryNames)
        {
            return _dbSet.Where(e => e.UserId == userId && !e.IsDeleted && categoryNames.Contains(e.CategoryName))
                   .Select(e => new CategoryViewModel
                   {
                       CategoryId = e.CategoryId,
                       CategoryName = e.CategoryName,
                       IsExpense = e.IsExpense
                   });
        }


        public bool CategoryNameExists(int userId, int categoryId, string categoryName)
        {
            return _dbSet.Where(e => e.UserId == userId && !e.IsDeleted && e.CategoryName == categoryName && e.CategoryId != categoryId)
                   .Select(e => e.CategoryId).Count() > 0;

        }
    }
}
