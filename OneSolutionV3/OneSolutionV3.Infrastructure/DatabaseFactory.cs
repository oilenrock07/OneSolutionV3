using System;
using OneSolutionV3.Domain.Models;

namespace OneSolutionV3.Infrastructure
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private OneSolutionContext _context;

        public OneSolutionContext GetOneSolutionContext()
        {
            return _context ?? (_context = new OneSolutionContext());
        }

        public System.Data.Common.DbConnection Connection()
        {
            return _context.Database.Connection;
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();

                GC.SuppressFinalize(this);
        }
    }
}
