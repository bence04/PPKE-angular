using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MyListsApp.API.DataTransferObjects;
using MyListsApp.API.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using TanulmanyiRendszer.API.Data;
using TanulmanyiRendszer.API.Models;

namespace MyListsApp.API.Services
{
    public class DefaultSzemeszterService : ISzemeszterService
    {
        private readonly TanulmanyiRendszerContext _context;
        private readonly IMapper _mapper;
        public DefaultSzemeszterService(TanulmanyiRendszerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<SzemeszterVM> GetSzemeszterAsync(int id)
        {
            return _context.Szemeszterek
                .ProjectTo<SzemeszterVM>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<SzemeszterVM>> GetSzemeszterekAsync()
        {
            return _context.Szemeszterek
                .ProjectTo<SzemeszterVM>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<SzemeszterVM> CreateSzemeszterAsync(SzemeszterDto szemeszterDto)
        {
            var szemeszter = _mapper.Map<Szemeszter>(szemeszterDto);
            
            _context.Szemeszterek.Add(szemeszter);
            await _context.SaveChangesAsync();

            return _mapper.Map<SzemeszterVM>(szemeszter);
        }

        public async Task UpdateSzemeszterAsync(int id, SzemeszterDto szemeszterDto)
        {
            var szemeszter = _mapper.Map<Szemeszter>(szemeszterDto);

            _context.Entry(szemeszter).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteSzemeszterAsync(int id)
        {
            var szemeszter = await _context.Szemeszterek.FindAsync(id);
            if (szemeszter == null)
            {
                return false;
            }

            _context.Szemeszterek.Remove(szemeszter);
            await _context.SaveChangesAsync();

            return true;
        }

        public Task<bool> SzemeszterExists(int id)
        {
            return _context.Szemeszterek.AnyAsync(e => e.Id == id);
        }
    }
}
