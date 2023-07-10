using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IDonatorService
    {
        Task<Donator> CreateOrUpdateDonatorAsync(string email, string mobileNumber, string fullName);
        Task<Donator> GetDonatorForUserAsync(string email);
    }

}