using System.ComponentModel.DataAnnotations;
namespace OneSolutionV3.Domain.Models
{
    public abstract class Person
    {
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string MiddleName { get; set; }
        [StringLength(50)]
        public string EmailAddress { get; set; }
    }
}
