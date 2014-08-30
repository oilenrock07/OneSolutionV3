using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OneSolutionV3.Domain.Models
{
    public class User : Person
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(20)]
        public string Password { get; set; }
        public bool IsRegistered { get; set; }
        
        [StringLength(5)]
        public string Currency { get; set; }
                
        //Fiscal Year
        public int MonthStart { get; set; }
        public int DayStart { get; set; }
        public int WeekDayStart { get; set; }

        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }

        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
    }
}
