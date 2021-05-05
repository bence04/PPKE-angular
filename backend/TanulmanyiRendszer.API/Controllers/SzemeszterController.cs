using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyListsApp.API.DataTransferObjects;
using MyListsApp.API.Services;
using MyListsApp.API.ViewModels;

namespace MyListsApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SzemeszterController : ControllerBase
    {
        private readonly ISzemeszterService _service;

        public SzemeszterController(ISzemeszterService service)
        {
            _service = service;
        }

        // GET: api/szemeszter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SzemeszterVM>>> GetSzemeszterek()
        {
            return await _service.GetSzemeszterekAsync();
        }

        // GET: api/szemeszter/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SzemeszterVM>> GetSzemeszter(int id)
        {
            var szemeszterVM = await _service.GetSzemeszterAsync(id);

            if (szemeszterVM == null)
            {
                return NotFound();
            }

            return szemeszterVM;
        }

        // PUT: api/szemeszter/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSzemeszter(int id, SzemeszterDto szemeszterDto)
        {
            if (id != szemeszterDto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateSzemeszterAsync(id, szemeszterDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _service.SzemeszterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/szemeszter
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SzemeszterVM>> PostSzemeszter(SzemeszterDto szemeszterDto)
        {
            var szemeszterVM = await _service.CreateSzemeszterAsync(szemeszterDto);

            return CreatedAtAction("GetSzemeszter", new { id = szemeszterVM.Id }, szemeszterVM);
        }

        // DELETE: api/szemeszter/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSzemeszter(int id)
        {
            if (!await _service.DeleteSzemeszterAsync(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
