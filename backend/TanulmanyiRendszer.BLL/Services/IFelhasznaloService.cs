using System.Threading;
using System.Threading.Tasks;

using TanulmanyiRendszer.BLL.DataTransferObjects;
using TanulmanyiRendszer.Domain;

namespace TanulmanyiRendszer.BLL.Services
{
    public interface IFelhasznaloService
    {
        Task<Felhasznalo> RegisterAsync(RegisterFelhasznaloDto dto, CancellationToken cancellationToken);
        Task<Felhasznalo> FindByFelhasznaloNevAsync(string felhasznaloNev, CancellationToken cancellationToken);
    }
}