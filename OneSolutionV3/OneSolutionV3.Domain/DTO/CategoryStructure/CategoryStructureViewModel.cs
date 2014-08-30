using System;

namespace OneSolutionV3.Domain.DTO.CategoryStructure
{
    public class CategoryStructureViewModel
    {
        public int CategoryStructureId { get; set; }
        public int CategoryId { get; set; }
        public int CategoryParentId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
