using System;
using Core.Entities;

namespace API.Dtos
{
    public class TokenDto
    {        
        public string TokenUID { get; set; }
        public string TokenName { get; set; }
        public string DonatorName{ get; set; }
        public string DonatorEmail { get; set; }
        public string StoreName{ get; set; }
        public string ProductType{ get; set; }      
        public string ProductName{ get; set; }
        public string RecipientName{ get; set; }      
        public decimal CostPrice { get; set; }
        public decimal SalesPrice { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateStoreAssigned { get; set; }
        public DateTime DateAssigned { get; set; }
        public DateTime DateCollected { get; set; }
        public DateTime DateRelease { get; set; }
        public DateTime DateExpire { get; set; }
        public bool FoodCollected { get; set; }
        public bool Valid { get; set; }
        public string ImageUrl { get; set; }
        public string ShortUrl { get; set; } 

    }
}
