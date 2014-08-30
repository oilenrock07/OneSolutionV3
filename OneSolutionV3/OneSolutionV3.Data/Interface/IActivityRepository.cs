using OneSolutionV3.Infrastructure;
using OneSolutionV3.Domain.Models;
using System.Collections.Generic;
using OneSolutionV3.Domain.DTO.Activity;

namespace OneSolutionV3.Service.Interface
{
    public interface IActivityRepository : IRepository<Activity, int>
    {
        IEnumerable<ActivityViewModel> GetTopTenActivity(int userId);
    }
}
