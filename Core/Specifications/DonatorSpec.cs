using Core.Entities;

namespace Core.Specifications
{
    public class DonatorSpec : BaseSpecification<Donator>
    {
        public DonatorSpec()
        {
            Includes.Add(x => x.Country);
        }

        public DonatorSpec(string id) : base(x => x.DonatorUID == id)
        {
            AddInclude(x => x.Country);
        }

    }          
}
