using OneSolutionV3.Infrastructure;
using OneSolutionV3.Domain.Models;
using System.Collections.Generic;
using OneSolutionV3.Domain.DTO.Bank;

namespace OneSolutionV3.Service.Interface
{
    public interface IBankRepository : IRepository<Bank, int>
    {
        IEnumerable<BankViewModel> GetBanksForDisplay(int userId);
        IEnumerable<BankNamesViewModel> GetBankNames(int userId);
        IEnumerable<BankNamesViewModel> GetBankNames(IEnumerable<int> bankIdList);
        string GetBankName(int userId, int bankId);
    }
}
