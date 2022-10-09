using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class StoreRecipient : BaseEntity
    {
        [Key]
        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string StoreRecipientUID { get; set; }

        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string StoreUID { get; set; } 

        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string RecipientUID { get; set; }    

        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string EmployeeUID { get; set; } 
        public DateTime DateRegistered { get; set; } = DateTime.UtcNow;
        public Recipient Recipient{ get; set; }    
        public Store Store{ get; set; }
    }
}