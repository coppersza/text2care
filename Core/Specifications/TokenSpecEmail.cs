using Core.Entities;

namespace Core.Specifications
{
    public class TokenSpecEmail : BaseSpecification<Token>
    {
        public TokenSpecEmail()
        {
            AddInclude(x => x.Product);
            AddInclude(x => x.Store);            
            AddInclude(x => x.Recipient);
            AddInclude(x => x.Donator);
            AddInclude("Product.ProductType"); 
        }
        public TokenSpecEmail(string id, string email) 
            : base(o => o.TokenUID == id && o.Donator.EmailAddress == email)        
        {
            AddInclude(x => x.Product);
            AddInclude(x => x.Store);            
            AddInclude(x => x.Recipient);
            AddInclude(x => x.Donator);
            AddInclude("Product.ProductType"); 
        }  
        public TokenSpecEmail(string email) : base(x => x.Donator.EmailAddress == email)
        {
            AddInclude(x => x.Product);
            AddInclude(x => x.Store);            
            AddInclude(x => x.Recipient);
            AddInclude(x => x.Donator);
            AddInclude("Product.ProductType"); 
        }        
    }          
}
