using Core.Entities;


namespace Core.Specifications
{
    public class ProductSpecCount : BaseSpecification<Product>
    {
        public ProductSpecCount(ProductSpecParams productSpecParams) : base(x =>
                (string.IsNullOrEmpty(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search)) &&
                (!productSpecParams.ProductTypeId.HasValue || x.ProductTypeId == productSpecParams.ProductTypeId) &&
                (string.IsNullOrEmpty(productSpecParams.StoreUID) || x.StoreUID == productSpecParams.StoreUID) &&
                (x.IsActive == productSpecParams.IsActive) 
            )
        {
        }
    }
}
