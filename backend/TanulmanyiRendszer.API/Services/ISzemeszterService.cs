using MyListsApp.API.DataTransferObjects;
using MyListsApp.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyListsApp.API.Services
{
    public interface ISzemeszterService
    {
        Task<List<SzemeszterVM>> GetSzemeszterekAsync();
        Task<SzemeszterVM> GetSzemeszterAsync(int id);
        Task<SzemeszterVM> CreateSzemeszterAsync(SzemeszterDto szemeszterDto);
        Task UpdateSzemeszterAsync(int id, SzemeszterDto szemeszterDto);
        Task<bool> DeleteSzemeszterAsync(int id);
        Task<bool> SzemeszterExists(int id);
    }
}
