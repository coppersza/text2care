using Core.Entities;

namespace Core.Specifications
{
    public class DonatorSpecEmail : BaseSpecification<Donator>
    {
        public DonatorSpecEmail()
        {
            Includes.Add(x => x.Country);
        }

        public DonatorSpecEmail(string email) : base(x => x.EmailAddress == email)
        {
            AddInclude(x => x.Country);
        }        
    }          
}
