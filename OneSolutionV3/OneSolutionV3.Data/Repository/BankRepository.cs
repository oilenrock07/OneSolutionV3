using OneSolutionV3.Infrastructure;
using OneSolutionV3.Domain.Models;
using OneSolutionV3.Service.Interface;
using System.Collections.Generic;
using OneSolutionV3.Domain.DTO.Bank;
using System.Linq;

namespace OneSolutionV3.Service.Repository
{
    public class BankRepository :Repository<Bank, int>, IBankRepository
    {
        public BankRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public IEnumerable<BankViewModel> GetBanksForDisplay(int userId)
        {
            var result = _dbSet.Where(e => e.UserId == userId && !e.IsDeleted)
                         .Select(e => new BankViewModel
                         {
                             BankId = e.BankId,
                             BankName = e.BankName,
                             Description = e.Description
                         });

            return result;
        }

        public string GetBankName(int userId, int bankId)
        {
            return _dbSet.FirstOrDefault(e => e.UserId == userId && e.BankId == bankId).BankName;
        }


        public IEnumerable<BankNamesViewModel> GetBankNames(int userId)
        {
            var result = _dbSet.Where(e => e.UserId == userId && !e.IsDeleted)
                         .Select(e => new BankNamesViewModel
                         {
                             BankId = e.BankId,
                             BankName = e.BankName
                         });

            return result;
        }


        public IEnumerable<BankNamesViewModel> GetBankNames(IEnumerable<int> bankIdList)
        {
            var result = _dbSet.Where(e => bankIdList.Contains(e.BankId))
                         .Select(e => new BankNamesViewModel
                         {
                             BankId = e.BankId,
                             BankName = e.BankName
                         });

            return result;
        }
    }
}
