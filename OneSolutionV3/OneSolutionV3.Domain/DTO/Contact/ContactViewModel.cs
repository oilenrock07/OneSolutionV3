using OneSolutionV3.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace OneSolutionV3.Domain.DTO.Contact
{
    public class ContactViewModel
    {
        public int ContactId { get; set; }

        [Required(ErrorMessage="First name is required")]
        [StringLength(25, ErrorMessage = "First Name must not be greater than 25 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage="Last name is required")]
        [StringLength(25, ErrorMessage = "Last Name must not be greater than 25 characters")]
        public string LastName { get; set; }

        [StringLength(25, ErrorMessage = "Middle Name must not be greater than 25 characters")]
        public string MiddleName { get; set; }

        [StringLength(15, ErrorMessage="Phone Number must not be greater than 15 characters")]
        public string PhoneNumber { get; set; }

        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress, ErrorMessage = "Invalid Email")]
        public string EmailAddress { get; set; }

        [StringLength(15, ErrorMessage = "Landline Number must not be greater than 15 characters")]
        public string LandLineNumber { get; set; }
        public string Comment { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1} {2}", this.FirstName, this.MiddleName, this.LastName);
            }
        }
    }
}
