using Microsoft.AspNetCore.Identity;

using System;
using System.Threading;
using System.Threading.Tasks;

using TanulmanyiRendszer.BLL.DataTransferObjects;
using TanulmanyiRendszer.Domain;

namespace TanulmanyiRendszer.BLL.Services
{
    public class IdentityFelhasznaloService : IFelhasznaloService
    {
        private readonly UserManager<Felhasznalo> _userManager;

        public IdentityFelhasznaloService(UserManager<Felhasznalo> userManager)
        {
            _userManager = userManager;
        }

        public Task<Felhasznalo> FindByFelhasznaloNevAsync(string felhasznaloNev, CancellationToken cancellationToken)
        {
            return _userManager.FindByNameAsync(felhasznaloNev);
        }

        public async Task<Felhasznalo> RegisterAsync(RegisterFelhasznaloDto dto, CancellationToken cancellationToken)
        {
            var felhasznalo = new Felhasznalo
            {
                UserName = dto.FelhasznaloNev,
                Email = dto.Email
            };

            var result = await _userManager.CreateAsync(felhasznalo, dto.Jelszo);

            if (!result.Succeeded)
            {
                throw new Exception("Felhasználó létrehozás nem sikerült!");
            }

            return felhasznalo;
        }
    }
}