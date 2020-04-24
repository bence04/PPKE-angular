using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Threading;
using System.Threading.Tasks;

using TanulmanyiRendszer.BLL.DataTransferObjects;
using TanulmanyiRendszer.BLL.Filters;
using TanulmanyiRendszer.BLL.Services;
using TanulmanyiRendszer.BLL.ViewModels;

namespace TanulmanyiRendszer.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SzemeszterekController : ControllerBase
    {
        private readonly ISzemeszterService _szemeszterService;

        public SzemeszterekController(ISzemeszterService szemeszterService)
        {
            _szemeszterService = szemeszterService;
        }

        [HttpGet]
        public async Task<ActionResult<ItemsViewModel<SzemeszterViewModel>>> Get([FromQuery]SzemeszterekListFilter filter, CancellationToken cancellationToken)
        {
            return await _szemeszterService.ListAsync(filter, cancellationToken);
        }

        [HttpPost]
        public Task<SzemeszterViewModel> Post([FromBody]SzemeszterDto dto, CancellationToken cancellationToken)
        {
            return _szemeszterService.CreateAsync(dto, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]SzemeszterDto dto, CancellationToken cancellationToken)
        {
            await _szemeszterService.UpdateAsync(id, dto, cancellationToken);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _szemeszterService.DeleteAsync(id, cancellationToken);

            return Ok();
        }
    }
}