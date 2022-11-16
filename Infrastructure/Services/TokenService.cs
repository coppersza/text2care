using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Identity;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TokenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Token> CreateOrUpdateTokenAsync(string tokenUID, string tokenName, int productId, string buyerEmail)
        {            
            var product = await _unitOfWork.Repository<Product>().GetByIdAsync(productId);
            var token = await _unitOfWork.Repository<Token>().GetByIdAsync(tokenUID);            

            var spec = new DonatorSpecEmail(buyerEmail);
            var donator = await _unitOfWork.Repository<Donator>().GetEntityWithSpec(spec);

            var donatorUID = Guid.Empty.ToString().ToUpper();
            if (donator == null)
            {
                //Need to add a donator if it doesnt already exist.
                donatorUID = Guid.NewGuid().ToString().ToUpper(); 
                var emailAddress = buyerEmail;
                var fullName = "";
                var mobileNumber = "";
                var countryId = 1;
                donator = new Donator(donatorUID, emailAddress, fullName, mobileNumber, countryId);
                _unitOfWork.Repository<Donator>().Add(donator);
            }            
            
            if (donator != null)
                donatorUID = donator.DonatorUID;

            if (token == null){
                var newTokenUID = Guid.NewGuid().ToString().ToUpper(); 
                token = new Token(newTokenUID, tokenName, donatorUID, product);
                _unitOfWork.Repository<Token>().Add(token);
                //save to db                             
            }else{
                token.TokenName = tokenName;
                token.ProductId = productId;
                if (donator != null)
                    token.DonatorUID = donatorUID;
                _unitOfWork.Repository<Token>().Update(token);
            }
            var result = await _unitOfWork.Complete();   
            if (result <= 0) return null;
            return token; 
        }

        public async Task<IReadOnlyList<Token>> GetTokensForUserAsync(string buyerEmail)
        {                       
            var spec = new TokenSpecEmail(buyerEmail);
            return await _unitOfWork.Repository<Token>().ListAsync(spec);
        }

        public async Task<IReadOnlyList<Token>> GetTokensForUserAsync(TokenSpecParams specParams)
        {
            var spec = new TokenSpec(specParams);
            var data = await _unitOfWork.Repository<Token>().ListAsync(spec);
            return data;        
        }
        public async Task<int> GetTokensForUserCountAsync(TokenSpecParams specParams)
        {
            var countSpec = new TokenSpecCount(specParams);
            var totalItems = await _unitOfWork.Repository<Token>().CountAsync(countSpec);
            return totalItems;        
        }        

        public async Task<Token> GetTokenByIdAsync(string id, string buyerEmail)
        {
            var spec = new TokenSpecEmail(id, buyerEmail);
            return await _unitOfWork.Repository<Token>().GetEntityWithSpec(spec);
        }
    }
}
