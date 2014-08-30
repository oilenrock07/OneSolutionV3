using OneSolutionV3.Infrastructure;
using OneSolutionV3.Domain.Models;
using OneSolutionV3.Domain.DTO.RecursiveTransaction;
using System.Collections.Generic;

namespace OneSolutionV3.Service.Interface
{
    public interface IRecursiveTransactionRepository : IRepository<RecursiveTransaction, int>
    {
        RecursiveTransactionViewModel GetRecursiveTransactions(int userId, int recursiveTransactionId);
        IEnumerable<RecursiveTransactionViewModel> GetRecursiveTransactions(int userId);        
    }
}
