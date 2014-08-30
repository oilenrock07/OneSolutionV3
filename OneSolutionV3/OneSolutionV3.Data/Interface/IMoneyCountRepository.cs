using OneSolutionV3.Infrastructure;
using OneSolutionV3.Domain.Models;
using OneSolutionV3.Domain.DTO.MoneyCount;
using System.Linq;

namespace OneSolutionV3.Service.Interface
{
    public interface IMoneyCountRepository : IRepository<MoneyCount, int>
    {
        IQueryable<MoneyCountDisplayViewModel> GetMoneyCounts(int userId);
    }
}
