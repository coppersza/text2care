using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class StoreSpec : BaseSpecification<Store>
    {
        public StoreSpec()
        {
            AddInclude(x => x.Country);
        }

        public StoreSpec(string id) : base(x => x.StoreUID == id)
        {
            AddInclude(x => x.Country);
        }

    }
    public class StoreSpecEmail : BaseSpecification<Store>
    {
        public StoreSpecEmail()
        {
            AddInclude(x => x.Country);
        }

        public StoreSpecEmail(string email) : base(x => x.EmailAddress == email)
        {
            AddInclude(x => x.Country);
        }
    }
}
