namespace API.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public string ProductType{ get; set; }
        public string StoreName{ get; set; }      
        public bool IsActive { get; set; }        
    }
}
