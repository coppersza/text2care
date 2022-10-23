using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Core.Entities
{
    public class Token : BaseEntity
    {
        public Token()
        {
        }

        public Token(string tokenUID, 
            string tokenName, 
            string donatorUID,
            Product product)
        {
            TokenUID = tokenUID;
            TokenName = tokenName; 
            Product = product;
            ProductId = product.Id;
            StoreUID = product.StoreUID;            
            RecipientUID = "00000000-0000-0000-0000-000000000000";
            DonatorUID = donatorUID;
            CostPrice = ((float)product.Price);
            SalesPrice = 0;
            ImageURL = "images/tokens/hourglass.png";
        }
        [Key]
        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string TokenUID { get; set; }   
        public string TokenName { get; set; }

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

        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string StoreMealUID { get; set; } 

        [Column(TypeName = "char(38)")]
        [StringLength(38)]
        public string RecipientUID { get; set; }
        public Recipient Recipient{ get; set; }

        public float CostPrice { get; set; }
        public float SalesPrice { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateStoreAssigned { get; set; } = DateTime.MinValue;
        public DateTime DateAssigned { get; set; } = DateTime.MinValue;
        public DateTime DateCollected { get; set; } = DateTime.MinValue;
        public DateTime DateRelease { get; set; } = DateTime.UtcNow;
        public DateTime DateExpire { get; set; } = DateTime.UtcNow.AddDays(60) ;
        public bool FoodCollected { get; set; } = false;
        public bool Valid { get; set; } = true;
        public string ImageURL { get; set; }
        public string ShortURL { get; set; }
        public string Description { get; set; } 
        public string RecipientName { get; set; }
        public string DonatorName { get; set; }

    }
}
