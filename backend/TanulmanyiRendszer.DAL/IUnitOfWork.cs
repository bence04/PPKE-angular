using System.Threading;
using System.Threading.Tasks;

using TanulmanyiRendszer.DAL.Repositories;

namespace TanulmanyiRendszer.DAL
{
    public interface IUnitOfWork
    {
        ISzemeszterRepository Szemeszterek { get; }

        Task CompleteAsync(CancellationToken cancellationToken);
    }
}