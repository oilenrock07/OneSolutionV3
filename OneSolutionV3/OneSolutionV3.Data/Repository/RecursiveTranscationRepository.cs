using OneSolutionV3.Infrastructure;
using OneSolutionV3.Domain.Models;
using OneSolutionV3.Service.Interface;
using System.Collections.Generic;
using OneSolutionV3.Domain.DTO.RecursiveTransaction;
using System.Linq;

namespace OneSolutionV3.Service.Repository
{
    public class RecursiveTranscationRepository : Repository<RecursiveTransaction, int> , IRecursiveTransactionRepository
    {
        private readonly IRecursiveTransactionDetailRepository _recursiveDetailRepository;

        public RecursiveTranscationRepository(IDatabaseFactory databaseFactory, IRecursiveTransactionDetailRepository recursiveDetailRepository)
            : base(databaseFactory)
        {
            _recursiveDetailRepository = recursiveDetailRepository;
        }

        public IEnumerable<RecursiveTransactionViewModel> GetRecursiveTransactions(int userId)
        {
            return _dbSet.Where(e => e.UserId == userId && !e.IsDeleted)
                   .Select(e => new
                   {
                       RecursiveTransactionId = e.RecursiveTransactionId,
                       Name = e.Name

                   }).ToList()
                   .Select(e => new RecursiveTransactionViewModel
                   {
                       RecursiveTransactionId = e.RecursiveTransactionId,
                       Name = e.Name,
                       TransactionList = _recursiveDetailRepository.GetRecursiveDetail(e.RecursiveTransactionId)
                   });
        }

        public RecursiveTransactionViewModel GetRecursiveTransactions(int userId, int recursiveTransactionId)
        {
            return _dbSet.Where(e => e.UserId == userId && !e.IsDeleted && e.RecursiveTransactionId == recursiveTransactionId)
                   .Select(e => new
                   {
                       RecursiveTransactionId = e.RecursiveTransactionId,
                       Name = e.Name

                   }).ToList()
                   .Select(e => new RecursiveTransactionViewModel
                   {
                       RecursiveTransactionId = e.RecursiveTransactionId,
                       Name = e.Name,
                       TransactionList = _recursiveDetailRepository.GetRecursiveDetail(e.RecursiveTransactionId)
                   }).FirstOrDefault();
        }
    }
}
