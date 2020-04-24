using System.Threading;
using System.Threading.Tasks;

using TanulmanyiRendszer.BLL.DataTransferObjects;
using TanulmanyiRendszer.BLL.Filters;
using TanulmanyiRendszer.BLL.ViewModels;

namespace TanulmanyiRendszer.BLL.Services
{
    public interface ISzemeszterService
    {
        Task<ItemsViewModel<SzemeszterViewModel>> ListAsync(SzemeszterekListFilter filter, CancellationToken cancellationToken);

        Task<SzemeszterViewModel> CreateAsync(SzemeszterDto dto, CancellationToken cancellationToken);

        Task UpdateAsync(int id, SzemeszterDto dto, CancellationToken cancellationToken);

        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}