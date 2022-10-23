using System;
using Core.Entities.OrderAggregate;

namespace API.Dtos.Orders
{
    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImageURL { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }        
    }
}
