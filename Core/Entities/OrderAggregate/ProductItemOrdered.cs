using System;

namespace Core.Entities.OrderAggregate
{
    public class ProductItemOrdered
    {
        public ProductItemOrdered()
        {
        }

        public ProductItemOrdered(int productItemId, string productName, string imageURL)
        {
            ProductItemId = productItemId;
            ProductName = productName;
            ImageURL = imageURL;
        }

        public int ProductItemId { get; set; }
        public string ProductName { get; set; }

        public string ImageURL { get; set; }
    }
}
