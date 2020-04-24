using AutoMapper;

using TanulmanyiRendszer.BLL.DataTransferObjects;
using TanulmanyiRendszer.BLL.ViewModels;
using TanulmanyiRendszer.Domain;

namespace TanulmanyiRendszer.BLL.Profiles
{
    public class SzemeszterMappingProfile : Profile
    {
        public SzemeszterMappingProfile()
        {
            CreateMap<SzemeszterDto, Szemeszter>();
            CreateMap<Szemeszter, SzemeszterViewModel>();
        }
    }
}