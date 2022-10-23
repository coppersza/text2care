using System;

namespace Core.Entities
{
    public class Country : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }  
        public string PortalUser { get; set; }
        public string PortalPassword { get; set; }               
    }
}
