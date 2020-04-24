using System.Threading;
using System.Threading.Tasks;

using TanulmanyiRendszer.API.Models;
using TanulmanyiRendszer.Domain;

namespace TanulmanyiRendszer.API.Services
{
    public interface ITokenService
    {
        Task<TokenViewModel> GenerateAsync(Felhasznalo felhasznalo, CancellationToken cancellationToken);
    }
}