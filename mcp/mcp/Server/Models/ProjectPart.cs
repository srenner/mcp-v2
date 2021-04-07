using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mcp.Server.Models
{
    public class ProjectPart
    {
        public int ProjectPartID { get; set; }

        public int ProjectID { get; set; }
        public Project Project { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string Manufacturer { get; set; }
        public string PartNumber { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }
        public string Link { get; set; }

        public int Quantity { get; set; }
        public int QuantityPurchased { get; set; }
        public int QuantityInstalled { get; set; }

        [NotMapped]
        public decimal MoneySpent
        {
            get
            {
                if(this.Price.HasValue)
                {
                    return this.Price.Value * this.QuantityPurchased;
                }
                else
                {
                    return 0.0M;
                }
            }
        }
    }
}
