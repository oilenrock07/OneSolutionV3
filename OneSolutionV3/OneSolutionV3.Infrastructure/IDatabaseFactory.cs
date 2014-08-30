using OneSolutionV3.Domain.Models;
using System.Data.Common;

namespace OneSolutionV3.Infrastructure
{
    public interface IDatabaseFactory
    {
        OneSolutionContext GetOneSolutionContext();
        DbConnection Connection();
        void Dispose();
    }
}
