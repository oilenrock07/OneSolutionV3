using System.Collections.Generic;
using System.Linq;
using OneSolutionV3.Service.Interface;
using OneSolutionV3.Infrastructure;
using OneSolutionV3.Domain.Models;
using OneSolutionV3.Domain.DTO.CategoryStructure;
using AutoMapper;
using System.Data.SqlClient;

namespace OneSolutionV3.Service.Repository
{
    public class CategoryStructureRepository : Repository<CategoryStructure, int>, ICategoryStructureRepository
    {
        public CategoryStructureRepository(IDatabaseFactory databaseFactory) 
            : base(databaseFactory)
        {
            
        }

        //Only gets the id, not all of the columns
        public IEnumerable<CategoryStructure> GetCategoryStructuresByParentId(int parentId)
        {
             var result =  base._context.CategoryStructure.Where(e => e.CategoryId == parentId && !e.IsDeleted)
                            .Select(q => new CategoryStructureViewModel
                            {
                                CategoryParentId = q.CategoryParentId
                            });

             return Mapper.Map<IEnumerable<CategoryStructure>>(result);

        }

        public bool CheckIfCategoryHasChild(int categoryId)
        {
            var count = base._context.CategoryStructure.Where(e => e.CategoryParentId == categoryId && e.CategoryId != categoryId).Count();
            return count > 0;
        }

        public void DeleteByCategoryId(int categoryId)
        {
            base.ExecuteSQLCommand("UPDATE CategoryStructures SET IsDeleted = 'true' WHERE CategoryId=@categoryId", new SqlParameter("categoryId", categoryId));
        }

    }
}
