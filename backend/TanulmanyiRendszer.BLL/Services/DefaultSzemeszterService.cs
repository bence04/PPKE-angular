using AutoMapper;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using TanulmanyiRendszer.BLL.DataTransferObjects;
using TanulmanyiRendszer.BLL.Filters;
using TanulmanyiRendszer.BLL.ViewModels;
using TanulmanyiRendszer.DAL;
using TanulmanyiRendszer.Domain;

namespace TanulmanyiRendszer.BLL.Services
{
    public class DefaultSzemeszterService : ISzemeszterService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DefaultSzemeszterService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<SzemeszterViewModel> CreateAsync(SzemeszterDto dto, CancellationToken cancellationToken)
        {
            var szemeszter = new Szemeszter
            {
                Kezdet = dto.Kezdet,
                Megnevezes = dto.Megnevezes
            };

            _unitOfWork.Szemeszterek.Add(szemeszter);

            await _unitOfWork.CompleteAsync(cancellationToken);

            return new SzemeszterViewModel
            {
                Id = szemeszter.Id
            };
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            _unitOfWork.Szemeszterek.Remove(id);

            await _unitOfWork.CompleteAsync(cancellationToken);
        }

        public async Task<ItemsViewModel<SzemeszterViewModel>> ListAsync(SzemeszterekListFilter filter, CancellationToken cancellationToken)
        {
            if (filter is null)
            {
                throw new System.ArgumentNullException(nameof(filter));
            }

            var szemeszterek = await _unitOfWork.Szemeszterek
                .GetAsync(filter.Skip, filter.Take, cancellationToken);

            var items = szemeszterek.Entities
                .Select(x => new SzemeszterViewModel
                {
                    Id = x.Id,
                    Megnevezes = x.Megnevezes,
                    Kezdet = x.Kezdet

                });

            return new ItemsViewModel<SzemeszterViewModel>
            {
                Items = items,
                TotalCount = szemeszterek.TotalCount
            };
        }

        public async Task UpdateAsync(int id, SzemeszterDto dto, CancellationToken cancellationToken)
        {
            if (dto is null)
            {
                throw new System.ArgumentNullException(nameof(dto));
            }

            var szemeszter = await _unitOfWork.Szemeszterek.FindByIdAsync(id, cancellationToken);

            szemeszter = _mapper.Map(dto, szemeszter);

            _unitOfWork.Szemeszterek.Update(szemeszter);

            await _unitOfWork.CompleteAsync(cancellationToken);
        }
    }
}