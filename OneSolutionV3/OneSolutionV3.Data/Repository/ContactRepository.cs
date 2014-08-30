using OneSolutionV3.Infrastructure;
using OneSolutionV3.Domain.Models;
using OneSolutionV3.Service.Interface;
using OneSolutionV3.Domain.DTO.Contact;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace OneSolutionV3.Service.Repository
{
    public class ContactRepository : Repository<Contact, int>, IContactRepository
    {
        public ContactRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public IEnumerable<ContactViewModel> GetContacts(int userId)
        {
            var result = _dbSet.Where(e => e.UserId == userId && !e.IsDeleted)
                         .Select(e => new ContactViewModel
                         {
                             Comment = e.Comment,
                             ContactId = e.ContactId,
                             EmailAddress = e.EmailAddress,
                             FirstName = e.FirstName,
                             LandLineNumber = e.LandLineNumber,
                             LastName = e.LastName,
                             MiddleName = e.MiddleName,
                             PhoneNumber = e.PhoneNumber
                         });

            return result;
        }


        public IEnumerable<ContactNamesViewModel> GetContactNames(int userId)
        {
            return _dbSet.Where(e => e.UserId == userId && !e.IsDeleted)
                   .Select(e => new
                   {
                       ContactId = e.ContactId,
                       FirstName = e.FirstName,
                       LastName = e.LastName,
                       MiddleName = e.MiddleName
                   }).ToList()
                   .Select(e => new ContactNamesViewModel
                   {
                       ContactId = e.ContactId,
                       ContactName = string.Format("{0} {1} {2}", e.FirstName, e.MiddleName, e.LastName)
                   });
        }
    }
}
