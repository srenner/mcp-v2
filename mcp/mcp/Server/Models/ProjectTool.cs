﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mcp.Server.Models
{
    public class ProjectTool
    {
        public int ProjectToolID { get; set; }

        public int ProjectID { get; set; }
        public Project Project { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string Manufacturer { get; set; }
        public string PartNumber { get; set; }

        [DataType(DataType.Currency)]
        public double? Price { get; set; }

        /// <summary>
        /// Portion of the tool price to be applied to this project
        /// </summary>
        [DataType(DataType.Currency)]
        public double? AppliedPrice { get; set; }

        public string Link { get; set; }

        public int Quantity { get; set; }
        public int QuantityPurchased { get; set; }

        public bool IsDeleted { get; set; }
    }
}
