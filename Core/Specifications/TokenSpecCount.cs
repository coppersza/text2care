using System;
using Core.Entities;

namespace Core.Specifications
{
    public class TokenSpecCount : BaseSpecification<Token>
    {
        public TokenSpecCount(TokenSpecParams specParams) : base(x => 
                ( string.IsNullOrEmpty(specParams.Search) || x.TokenName.ToLower().Contains(specParams.Search) ) &&
                (!specParams.ProductTypeId.HasValue || x.Product.ProductTypeId == specParams.ProductTypeId) && 
                (string.IsNullOrEmpty(specParams.StoreUID) || x.StoreUID == specParams.StoreUID) &&
                (string.IsNullOrEmpty(specParams.RecipientUID) || x.RecipientUID == specParams.RecipientUID) &&
                (string.IsNullOrEmpty(specParams.DonatorUID) || x.DonatorUID == specParams.DonatorUID) &&
                (string.IsNullOrEmpty(specParams.DonatorEmail) || x.Donator.EmailAddress == specParams.DonatorEmail) )
        {
        }        
 
    }
}
