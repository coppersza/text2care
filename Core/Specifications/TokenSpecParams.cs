using System;

namespace Core.Specifications
{
    public class TokenSpecParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 6;
        public int PageSize
        {   
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public string StoreUID { get; set; }
        public string RecipientUID { get; set; }
        public string DonatorUID { get; set; }        
        public string DonatorEmail { get; set; }  
        public int? ProductTypeId { get; set; }
        public int? ProductId { get; set; }

        public string Sort { get; set; }

        private string _search;
        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }    
}
