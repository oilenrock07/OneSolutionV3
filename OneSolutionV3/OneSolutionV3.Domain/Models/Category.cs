using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneSolutionV3.Domain.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsExpense { get; set; }

        public DateTime DateCreated { get; set; }

        [ForeignKey("ParentCategory")]
        public int ? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set;}

        [NotMapped]
        public string CategoryType
        {
            get
            {
                return IsExpense ? "Expense" : "Income";
            }
        }

    }
}
