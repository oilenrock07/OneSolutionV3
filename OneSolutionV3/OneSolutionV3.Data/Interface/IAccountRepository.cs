using OneSolutionV3.Infrastructure;
using OneSolutionV3.Domain.Models;
using System.Collections.Generic;
using OneSolutionV3.Domain.DTO.Account;

namespace OneSolutionV3.Service.Interface
{
    public interface IAccountRepository : IRepository<Account, int>
    {
        IEnumerable<AccountViewModel> GetAccountId(int userId, bool excludeCreditCard = false);
        IEnumerable<AccountViewModel> GetAccountId(int userId, IEnumerable<string> accountNames);
        IEnumerable<AccountDisplayViewModel> GetAccountAmount(int userId, bool excludeCreditCard = false);
        IEnumerable<AccountAmountViewModel> GetAccountAmount(IEnumerable<int> AccountId, bool excludeCreditCard = false);        
        IEnumerable<AccountMainViewModel> GetAccounts(int userId);
        IEnumerable<string> GetAccountNames(int userId);
        double GetAmountUsingAccountId(int accountId);
    }
}
