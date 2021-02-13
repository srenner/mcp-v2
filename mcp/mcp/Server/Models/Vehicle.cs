using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mcp.Server.Models
{
    /// <summary>
    /// A user's car, truck, motorcycle, etc.
    /// </summary>
    public class Vehicle
    {
        [Key]
        public int VehicleID { get; set; }

        public string UserID { get; set; }
        public ApplicationUser User { get; set; }

        public string Name { get; set; }
        public DateTime? PurchaseDate { get; set; }
        [DataType(DataType.Currency)]
        public Decimal? PurchasePrice { get; set; }
        [DataType(DataType.Currency)]
        public Decimal? TotalInvested { get; set; }
        [DataType(DataType.Currency)]
        public Decimal? EstimatedValue { get; set; }
        public bool IsForSale { get; set; }
        public string ForSaleLink { get; set; }
        [DataType(DataType.Currency)]
        public Decimal? ForSaleAskingPrice { get; set; }
        [DataType(DataType.Currency)]
        public Decimal? ForSaleTransactionPrice { get; set; }
        public bool IsSold { get; set; }
        public bool IsDeleted { get; set; }

        public List<Project> Projects { get; set; }
        public List<VehicleModification> Modifications { get; set; }

    }
}
