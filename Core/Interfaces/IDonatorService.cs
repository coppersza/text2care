using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IDonatorService
    {
        Task<Donator> CreateOrUpdateDonatorAsync(string buyerEmail, string mobileNumber, string fullName);
        Task<IReadOnlyList<Donator>> GetDonatorForUserAsync(string buyerEmail);         
    }
}