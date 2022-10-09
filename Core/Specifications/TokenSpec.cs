using System;
using Core.Entities;
namespace Core.Specifications
{
    public class TokenSpec: BaseSpecification<Token>
    {
        public TokenSpec(TokenSpecParams specParams) : base(x => 
                ( string.IsNullOrEmpty(specParams.Search) || x.TokenName.ToLower().Contains(specParams.Search) ) &&
                (!specParams.ProductTypeId.HasValue || x.Product.ProductTypeId == specParams.ProductTypeId) && 
                (string.IsNullOrEmpty(specParams.StoreUID) || x.StoreUID == specParams.StoreUID) &&
                (string.IsNullOrEmpty(specParams.RecipientUID) || x.RecipientUID == specParams.RecipientUID) &&
                (string.IsNullOrEmpty(specParams.DonatorUID) || x.DonatorUID == specParams.DonatorUID) &&
                (string.IsNullOrEmpty(specParams.DonatorEmail) || x.Donator.EmailAddress == specParams.DonatorEmail) )
        {
            AddInclude(x => x.Product);
            AddInclude("Product.Store");           
            AddInclude("Product.ProductType"); 

            AddInclude(x => x.Recipient);
            AddInclude(x => x.Donator);

            AddOrderBy(x => x.TokenName);
            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
            if (!string.IsNullOrEmpty(specParams.Sort)){
                switch (specParams.Sort){
                    case "dateAsc":
                        AddOrderBy(p => p.DateCreated);
                        break;
                    case "dateDesc":
                        AddOrderByDescending(p => p.DateCreated);
                        break;
                    default:
                        AddOrderBy(n => n.TokenName);
                        break;                      
                }
            }            
        }        


        public TokenSpec(string id) : base(x => x.TokenUID == id)
        {
            AddInclude(x => x.Product);
            AddInclude("Product.Store");
            AddInclude("Product.ProductType");

            AddInclude(x => x.Recipient);     
            AddInclude(x => x.Donator);       
        }     

        
   
    }
}
