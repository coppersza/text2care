using System;

namespace API.Dtos
{
    public class StoreDto
    {
        public string StoreUID { get; set; }
        public string StoreName { get; set; }
        public string Description { get; set; } 
        public string ImageURL { get; set; }        
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }     
        public string Country{ get; set; }             
    }
}
