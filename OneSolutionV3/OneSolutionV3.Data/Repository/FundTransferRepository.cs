using OneSolutionV3.Infrastructure;
using OneSolutionV3.Domain.Models;
using OneSolutionV3.Service.Interface;
using System.Collections.Generic;
using OneSolutionV3.Domain.DTO.FundTransfer;
using System.Linq;

namespace OneSolutionV3.Service.Repository
{
    public class FundTransferRepository : Repository<FundTransfer, int>, IFundTransferRepository
    {
        public FundTransferRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }


        public IEnumerable<FundTransferViewModel> GetFundTransfers(int userId)
        {
            return _dbSet.Where(e => e.UserId == userId && !e.IsDeleted)
                   .Select(e => new FundTransferViewModel
                   {
                       FundTransferId = e.FundTransferId,
                       Amount = e.Amount,
                       Comment = e.Comment,
                       DateTransfer = e.DateTransfer,
                       FromAccountId = e.FromAccountId,
                       FromAccountName = e.FromAccount.AccountName,
                       ToAccountId = e.ToAccountId,
                       ToAccountName = e.ToAccount.AccountName
                   });
        }
    }
}
