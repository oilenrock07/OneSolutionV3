using System.Linq;
using OneSolutionV3.Infrastructure;
using OneSolutionV3.Domain.Models;
using OneSolutionV3.Service.Interface;

namespace OneSolutionV3.Service.Repository
{
    public class UserRepository : Repository<User, int>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
        public User ValidateUser(string emailAddress, string password)
        {
            return this._dbSet.Where(e => e.EmailAddress == emailAddress && e.Password == password).FirstOrDefault();
        }

        public bool IsEmailExists(string emailAddress)
        {
            return this._dbSet.Where(e => e.EmailAddress == emailAddress).FirstOrDefault() != null;
        }
    }
}
