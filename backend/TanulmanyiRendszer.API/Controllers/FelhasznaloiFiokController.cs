using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Threading;
using System.Threading.Tasks;

using TanulmanyiRendszer.API.Models;
using TanulmanyiRendszer.API.Services;
using TanulmanyiRendszer.BLL.DataTransferObjects;
using TanulmanyiRendszer.BLL.Services;
using TanulmanyiRendszer.Domain;

namespace TanulmanyiRendszer.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FelhasznaloiFiokController : ControllerBase
    {
        private readonly IFelhasznaloService _felhasznaloService;
        private readonly SignInManager<Felhasznalo> _signInManager;
        private readonly ITokenService _tokenService;

        public FelhasznaloiFiokController(IFelhasznaloService felhasznaloService, SignInManager<Felhasznalo> signInManager, ITokenService tokenService)
        {
            _felhasznaloService = felhasznaloService;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterFelhasznaloDto dto, CancellationToken cancellationToken)
        {
            await _felhasznaloService.RegisterAsync(dto, cancellationToken);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesDefaultResponseType(typeof(TokenViewModel))]
        public async Task<IActionResult> Login([FromBody] FelhasznaloLoginDto dto, CancellationToken cancellationToken)
        {
            const string hibasBejelentkezesUzenet = "Hibás felhasználónév vagy jelszó";

            var felhasznalo = await _felhasznaloService.FindByFelhasznaloNevAsync(dto.FelhasznaloNev, cancellationToken);

            if (felhasznalo == null)
            {
                return BadRequest(hibasBejelentkezesUzenet);
            }

            var result = await _signInManager.CheckPasswordSignInAsync(felhasznalo, dto.Jelszo, false);

            if (!result.Succeeded)
            {
                return BadRequest(hibasBejelentkezesUzenet);
            }

            var token = await _tokenService.GenerateAsync(felhasznalo, cancellationToken);

            return Ok(token);
        }
    }
}