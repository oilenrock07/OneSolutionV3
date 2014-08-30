using OneSolutionV3.Infrastructure;
using OneSolutionV3.Domain.Models;
using System.Collections.Generic;
using OneSolutionV3.Domain.DTO.FundTransfer;

namespace OneSolutionV3.Service.Interface
{
    public interface IFundTransferRepository : IRepository<FundTransfer, int>
    {
        IEnumerable<FundTransferViewModel> GetFundTransfers(int userId);
    }
}
