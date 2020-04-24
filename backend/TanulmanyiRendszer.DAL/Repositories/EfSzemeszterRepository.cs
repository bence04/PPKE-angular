using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

using TanulmanyiRendszer.Domain;

namespace TanulmanyiRendszer.DAL.Repositories
{
    public class EfSzemeszterRepository : ISzemeszterRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EfSzemeszterRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Szemeszter szemeszter)
        {
            _dbContext.Add(szemeszter);
        }

        public async ValueTask<Szemeszter> FindByIdAsync(int id, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Szemeszterek.FindAsync(id);

            if (result == default)
            {
                throw new Exception("Erőforrás nem található.");
            }

            return result;
        }

        public async Task<QueryResult<Szemeszter>> GetAsync(int skip, int take, CancellationToken cancellationToken)
        {
            var totalCount = await _dbContext.Szemeszterek
                .CountAsync(cancellationToken);

            var entities = await _dbContext.Szemeszterek
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            return new QueryResult<Szemeszter>
            {
                Entities = entities,
                TotalCount = totalCount
            };
        }

        public async Task<QueryResult<Szemeszter>> GetAsync(Expression<Func<Szemeszter, bool>> filter, int skip, int take, CancellationToken cancellationToken)
        {
            if (filter is null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            var query = _dbContext.Szemeszterek
                .Where(filter);

            var totalCount = await query
                .CountAsync(cancellationToken);

            var entities = await query
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            return new QueryResult<Szemeszter>
            {
                Entities = entities,
                TotalCount = totalCount
            };
        }

        public void Remove(int id)
        {
            var entity = _dbContext.Szemeszterek.Find(id);

            _dbContext.Remove(entity);
        }

        public void Update(Szemeszter szemeszter)
        {
            _dbContext.Szemeszterek.Update(szemeszter);
        }
    }
}