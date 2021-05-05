using AutoMapper;
using MyListsApp.API.DataTransferObjects;
using MyListsApp.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TanulmanyiRendszer.API.Models;

namespace MyListsApp.API.Profiles
{
    public class SzemeszterProfile : Profile
    {
        public SzemeszterProfile()
        {
            CreateMap<SzemeszterDto, Szemeszter>();
            CreateMap<Szemeszter, SzemeszterVM>();
        }
    }
}
