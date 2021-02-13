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








}
