using OneSolutionV3.Infrastructure;
using OneSolutionV3.Domain.Models;
using OneSolutionV3.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using OneSolutionV3.Domain.DTO.Activity;

namespace OneSolutionV3.Service.Repository
{
    public class ActivityRepository : Repository<Activity, int> , IActivityRepository
    {
        public ActivityRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public IEnumerable<ActivityViewModel> GetTopTenActivity(int userId)
        {
            return this._dbSet.Where(e => e.UserId == userId)
                   .Select(e => new
                   {
                       e.ActivityType,
                       e.DateCreated,
                       e.Description
                   })
                   .OrderByDescending(e => e.DateCreated)
                   .Take(10)
                   .Select(e => new ActivityViewModel
                   {
                       ActivityType = e.ActivityType,
                       DateCreated = e.DateCreated,
                       Description = e.Description
                   });
        }
    }
}
