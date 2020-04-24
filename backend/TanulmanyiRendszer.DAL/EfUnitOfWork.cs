using System.Threading;
using System.Threading.Tasks;

using TanulmanyiRendszer.DAL.Repositories;

namespace TanulmanyiRendszer.DAL
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        private ISzemeszterRepository _szemeszterRepository;

        public EfUnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ISzemeszterRepository Szemeszterek
        {
            get
            {
                return _szemeszterRepository ?? (_szemeszterRepository = new EfSzemeszterRepository(_dbContext));
            }
        }

        public Task CompleteAsync(CancellationToken cancellationToken)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}