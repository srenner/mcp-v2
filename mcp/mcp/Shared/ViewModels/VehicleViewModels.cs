using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcp.Shared.ViewModels
{
    public class VehicleListItemViewModel
    {
        public int VehicleID { get; set; }
        public string Name { get; set; }
        public bool IsForSale { get; set; }
        public decimal? ForSaleAskingPrice { get; set;}
        public bool IsSold { get; set; }
        public int ProjectCount { get; set; }
        public int ModificationCount { get; set; }
    }


    public class VehicleViewModel
    {
        public int VehicleID { get; set; }

        public string UserID { get; set; }
        public string UserUniqueName { get; set; }
        public string UserDisplayName { get; set; }

        public string Name { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public Decimal? PurchasePrice { get; set; }
        public Decimal? TotalInvested { get; set; }
        public Decimal? EstimatedValue { get; set; }
        public bool IsForSale { get; set; }
        public string ForSaleLink { get; set; }
        public Decimal? ForSaleAskingPrice { get; set; }
        public Decimal? ForSaleTransactionPrice { get; set; }
        public bool IsSold { get; set; }
        public bool IsDeleted { get; set; }
    }


}
