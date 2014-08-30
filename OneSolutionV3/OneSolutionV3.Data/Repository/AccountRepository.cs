using OneSolutionV3.Infrastructure;
using OneSolutionV3.Domain.Models;
using OneSolutionV3.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using OneSolutionV3.Domain.DTO.Account;
using OneSolutionV3.Common.Utility;

namespace OneSolutionV3.Service.Repository
{
    public class AccountRepository : Repository<Account, int>, IAccountRepository
    {
        public AccountRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public IEnumerable<AccountViewModel> GetAccountId(int userId, bool excludeCreditCard = false)
        {
            int creditCardType = excludeCreditCard ? (int)Account.AccountTypes.CreditCard : 0;

            return _dbSet.Where(e => e.UserId == userId && !e.IsDeleted && e.AccountType != creditCardType)
                   .Select(e => new AccountViewModel
                   {
                       AccountId = e.AccountId,
                       AccountName = e.AccountName
                   });
        }

        public IEnumerable<AccountAmountViewModel> GetAccountAmount(IEnumerable<int> AccountId, bool excludeCreditCard = false)
        {
            int creditCardType = excludeCreditCard ? (int)Account.AccountTypes.CreditCard : 0;

            return _dbSet.Where(e => AccountId.Contains(e.AccountId) && e.AccountType != creditCardType)
                   .Select(e => new AccountAmountViewModel
                   {
                       AccountId = e.AccountId,
                       Amount = e.Amount
                   });
        }


        public IEnumerable<AccountDisplayViewModel> GetAccountAmount(int userId, bool excludeCreditCard = false)
        {
            int creditCardType = excludeCreditCard ? (int)Account.AccountTypes.CreditCard : 0;

            return _dbSet.Where(e => e.UserId == userId && !e.IsDeleted && e.AccountType != creditCardType)
                   .Select(e => new AccountDisplayViewModel
                   {
                       AccountId = e.AccountId,
                       AccountName = e.AccountName,
                       Amount = e.Amount
                   });
        }


        public IEnumerable<AccountMainViewModel> GetAccounts(int userId)
        {
            var accounts = _dbSet.Where(e => e.UserId == userId && !e.IsDeleted)
                           .Select(e => new
                           {
                               AccountId = e.AccountId,
                               AccountType = e.AccountType,
                               Amount = e.Amount,
                               BankName = e.Bank.BankName
                           }).ToList()
                           .Select(e => new AccountMainViewModel
                            {
                                AccountId = e.AccountId,
                                AccountType = e.AccountType,
                                AccountTypeName = ((Account.AccountTypes)e.AccountType).ToDescriptionString(),
                                BankName = e.BankName,
                                Amount = e.Amount
                            });

            return accounts;
        }


        public IEnumerable<string> GetAccountNames(int userId)
        {
            return _dbSet.Where(e => e.UserId == userId && !e.IsDeleted)
                   .Select(e => e.AccountName);
        }


        public IEnumerable<AccountViewModel> GetAccountId(int userId, IEnumerable<string> accountNames)
        {
            return _dbSet.Where(e => e.UserId == userId && !e.IsDeleted && accountNames.Contains(e.AccountName))
                   .Select(e => new AccountViewModel
                   {
                       AccountId = e.AccountId,
                       AccountName = e.AccountName
                   });
        }

        public double GetAmountUsingAccountId(int accountId)
        {
            return _dbSet.Where(e => e.AccountId == accountId)
                   .Select(e => e.Amount)
                   .FirstOrDefault();
            //return FindById(accountId).Amount;
        }
    }
}
