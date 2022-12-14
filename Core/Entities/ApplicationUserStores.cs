using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class ApplicationUserStores : BaseEntity
    {
        [Key]
        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string ApplicationUserStoreUID { get; set; }     
           
        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string ApplicationUserId { get; set; }

        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string StoreUID { get; set; }   
                    
    }
}
