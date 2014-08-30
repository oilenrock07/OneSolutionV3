using System.Linq;
using OneSolutionV3.Service.Interface;
using OneSolutionV3.Domain.Models;
using OneSolutionV3.Domain.DTO.MoneyCount;
using OneSolutionV3.Infrastructure;

namespace OneSolutionV3.Service.Repository
{
    public class MoneyCountRepository : Repository<MoneyCount, int>, IMoneyCountRepository
    {
        public MoneyCountRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public IQueryable<MoneyCountDisplayViewModel> GetMoneyCounts(int userId)
        {
            return _dbSet.Where(e => e.UserId == userId && !e.IsDeleted)
                         .Select(e => new MoneyCountDisplayViewModel
                         {
                             AccountId = e.AccountId,
                             AccountName = e.Account.AccountName,
                             Amount = e.Amount,
                             DateCreated = e.DateCreated,
                             Discrepancy = e.Discrepancy,
                             MoneyCountId = e.MoneyCountId,
                             TransactionDate = e.TransactionDate,
                             Remarks = e.Remarks
                         });
        }
    }
}
