namespace Core.Entities
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public string ImageURL { get; set; }

        public string StoreName { get; set; }

        public string ProductType { get; set; }
    }
}