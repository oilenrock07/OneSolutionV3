using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OneSolutionV3.Domain.Models
{
    public class Bank
    {
        [Key]
        public int BankId { get; set; }
        
        [StringLength(50)]
        public string BankName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }        

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public bool IsDeleted { get; set; }       
        public DateTime DateCreated { get; set; }
    }
}
