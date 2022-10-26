using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Transaction : BaseEntity
    {
        public int TransactionID { get; set; }
        
        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string DonatorUID { get; set; }
        public Donator Donator{ get; set; }

        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string StoreUID { get; set; }
        public Store Store{ get; set; }   
        public int ProductId { get; set; }  
        public Product Product{ get; set; }      
        public int CountryId { get; set; }
        public Country Country{ get; set; }               

        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string EmployeeUID { get; set; }  
        public float CostPrice { get; set; }      
        public DateTime DatePurchased { get; set; } = DateTime.UtcNow;    
        public int MealsPerWeek { get; set; }
        public int MealsPerMonth { get; set; }
        public bool Recurring { get; set; } = false;
    }
}