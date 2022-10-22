using System;

namespace API.Dtos
{
    public class DonatorDto
    {
        public string DonatorUID { get; set; }
        public string Description { get; set; } 
        public string ImageUrl { get; set; }        
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public string Country{ get; set; }        
    }
}
