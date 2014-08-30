using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneSolutionV3.Domain.Models
{
    public class CategoryStructure
    {
        [Key]
        public int CategoryStructureId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("CategoryParent")]
        public int CategoryParentId { get; set; }
        public virtual Category CategoryParent { get; set; }

        public int Level { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
