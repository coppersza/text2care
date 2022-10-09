using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Transaction : BaseEntity
    {
        public int Id { get; set; }
        
        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string DonatorUID { get; set; }
        public int DonatorId { get; set; }

        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string StoreUID { get; set; }
        public int StoreId { get; set; }

        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string EmployeeUID { get; set; }  
        public int EmployeeId { get; set; }

        public decimal CostPrice { get; set; }      
        public DateTime DatePurchased { get; set; } = DateTime.UtcNow;    
        public int MealsPerWeek { get; set; }
        public int MealsPerMonth { get; set; }
        public bool Recurring { get; set; } = false;
    }
}