using OneSolutionV3.Domain.Models;
using OneSolutionV3.Infrastructure;

namespace OneSolutionV3.Service.Interface
{
    public interface IUserRepository : IRepository<User, int>
    {
        User ValidateUser(string emailAddress, string password);
        bool IsEmailExists(string emailAddress);
    }
}
