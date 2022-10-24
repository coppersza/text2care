using Core.Entities;

namespace Core.Specifications
{
    public class DonatorSpecMobileNumber : BaseSpecification<Donator>
    {
        public DonatorSpecMobileNumber()
        {
            Includes.Add(x => x.Country);
        }

        public DonatorSpecMobileNumber(string mobileNumber) : base(x => x.MobileNumber == mobileNumber)
        {
            AddInclude(x => x.Country);
        }        
    }          
}
