using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface ITokenService
    {
        Task<Token> CreateOrUpdateTokenAsync(string tokenUID, string tokenName, int productId, string buyerEmail);
        Task<IReadOnlyList<Token>> GetTokensForUserAsync(string buyerEmail);
        Task<IReadOnlyList<Token>> GetTokensForUserAsync(TokenSpecParams specParams);
        Task<int> GetTokensForUserCountAsync(TokenSpecParams specParams);
        Task<Token> GetTokenByIdAsync(string id, string buyerEmail);  
    }
}
