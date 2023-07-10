using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IStoreService
    {
        Task<Store> GetStoreForUserAsync(string email);
    }
}