using System;

namespace Core.Entities.OrderAggregate
{
    public class ProductItemOrdered
    {
        public ProductItemOrdered()
        {
        }

        public ProductItemOrdered(int productItemId, string productName, string imageUrl)
        {
            ProductItemId = productItemId;
            ProductName = productName;
            ImageURL = imageUrl;
        }

        public int ProductItemId { get; set; }
        public string ProductName { get; set; }

        public string ImageURL { get; set; }
    }
}
