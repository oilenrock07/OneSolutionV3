using OneSolutionV3.Infrastructure;
using OneSolutionV3.Domain.Models;
using OneSolutionV3.Service.Interface;
using OneSolutionV3.Domain.DTO.RecursiveTransaction;
using System.Collections.Generic;
using System.Linq;

namespace OneSolutionV3.Service.Repository
{
    public class RecursiveTransactionDetailRepository : Repository<RecursiveTransactionDetail, int>, IRecursiveTransactionDetailRepository
    {
        public RecursiveTransactionDetailRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public IEnumerable<RecursiveDetail> GetRecursiveDetail(int recursiveTransactionId)
        {
            return _dbSet.Where(e => e.RecursiveTransactionId == recursiveTransactionId && !e.IsDeleted)
                   .Select(e => new RecursiveDetail
                   {
                        RecursiveTransactionDetailId = e.RecursiveTransactionDetailId,
                       AccountId = e.Account.AccountId,
                       Amount = e.Amount,
                       AccountName = e.Account.AccountName,
                       CategoryName = e.Category.CategoryName,
                       CategoryId = e.Category.CategoryId,
                       Remarks = e.Remarks,
                       IsExpense = e.Category.IsExpense
                   });
        }
    }
}
