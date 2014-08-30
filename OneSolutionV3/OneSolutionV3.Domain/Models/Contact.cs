using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneSolutionV3.Domain.Models
{
    public class Contact : Person
    {
        [Key]
        public int ContactId { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(20)]
        public string LandLineNumber { get; set; }

        [StringLength(500)]
        public string Comment { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime DateCreated { get; set; }

        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
    }
}
