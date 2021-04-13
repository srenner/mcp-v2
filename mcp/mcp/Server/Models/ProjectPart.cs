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

        /// <summary>
        /// Price per part to be multiplied by quantity
        /// </summary>
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }

        /// <summary>
        /// Extra cost for a part independent of part quantity (shipping, tax, etc.)
        /// </summary>
        [DataType(DataType.Currency)]
        public decimal? ExtraCost { get; set; }

        public string Link { get; set; }

        public int Quantity { get; set; }
        public int QuantityPurchased { get; set; }
        public int QuantityInstalled { get; set; }

        [NotMapped]
        public decimal MoneySpent
        {
            get
            {
                var spent = 0.0M;
                if(this.Price.HasValue)
                {
                    spent += this.Price.Value * this.QuantityPurchased;
                }
                if (this.ExtraCost.HasValue)
                {
                    spent += this.ExtraCost.Value;
                }
                return spent;
            }
        }

    }
}
