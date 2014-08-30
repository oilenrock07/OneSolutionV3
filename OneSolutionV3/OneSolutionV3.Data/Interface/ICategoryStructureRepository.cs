using System.Collections.Generic;
using OneSolutionV3.Domain.Models;
using OneSolutionV3.Infrastructure;
using OneSolutionV3.Domain.DTO.CategoryStructure;

namespace OneSolutionV3.Service.Interface
{
    public interface ICategoryStructureRepository : IRepository<CategoryStructure, int>
    {
        IEnumerable<CategoryStructure> GetCategoryStructuresByParentId(int parentId);
        bool CheckIfCategoryHasChild(int categoryId);
        void DeleteByCategoryId(int categoryId);
    }
}
