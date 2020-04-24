using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

using TanulmanyiRendszer.Domain;

namespace TanulmanyiRendszer.DAL.Repositories
{
    public interface ISzemeszterRepository
    {
        void Add(Szemeszter szemeszter);

        void Update(Szemeszter szemeszter);

        void Remove(int id);

        ValueTask<Szemeszter> FindByIdAsync(int id, CancellationToken cancellationToken);

        Task<QueryResult<Szemeszter>> GetAsync(int skip, int take, CancellationToken cancellationToken);

        Task<QueryResult<Szemeszter>> GetAsync(Expression<Func<Szemeszter, bool>> filter, int skip, int take, CancellationToken cancellationToken);
    }
}