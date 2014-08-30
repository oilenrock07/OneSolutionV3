using OneSolutionV3.Infrastructure;
using OneSolutionV3.Domain.Models;
using System.Collections.Generic;
using OneSolutionV3.Domain.DTO.Contact;

namespace OneSolutionV3.Service.Interface
{
    public interface IContactRepository : IRepository<Contact, int>
    {
        IEnumerable<ContactViewModel> GetContacts(int userId);
        IEnumerable<ContactNamesViewModel> GetContactNames(int userId);
    }
}
