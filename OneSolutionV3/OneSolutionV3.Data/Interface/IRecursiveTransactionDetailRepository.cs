using OneSolutionV3.Infrastructure;
using OneSolutionV3.Domain.Models;
using OneSolutionV3.Domain.DTO.RecursiveTransaction;
using System.Collections.Generic;

namespace OneSolutionV3.Service.Interface
{
    public interface IRecursiveTransactionDetailRepository : IRepository<RecursiveTransactionDetail, int>
    {
        IEnumerable<RecursiveDetail> GetRecursiveDetail(int recursiveTransactionId);
    }
}
