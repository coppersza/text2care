using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductSpec : BaseSpecification<Product>
    {

        public ProductSpec(ProductSpecParams specParams) 
            : base(x => 
                (string.IsNullOrEmpty(specParams.Search) || x.Name.ToLower().Contains(specParams.Search)) &&
                (!specParams.ProductTypeId.HasValue || x.ProductTypeId == specParams.ProductTypeId) && 
                (string.IsNullOrEmpty(specParams.StoreUID) || x.StoreUID == specParams.StoreUID) &&
                (x.IsActive == specParams.IsActive) 

            )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.Store);
            AddOrderBy(x => x.Name);
            
            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
            if (!string.IsNullOrEmpty(specParams.Sort)){
                switch (specParams.Sort){
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;                      
                }
            }
        }

        public ProductSpec(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.Store);            
        }
    }
}
