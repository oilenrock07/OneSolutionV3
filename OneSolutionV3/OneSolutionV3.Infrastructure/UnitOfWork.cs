using OneSolutionV3.Domain.Models;

namespace OneSolutionV3.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory _databaseFactory;
        private OneSolutionContext _context;
        
        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
            _context = _databaseFactory.GetOneSolutionContext();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
