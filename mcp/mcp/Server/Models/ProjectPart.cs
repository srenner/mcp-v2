using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [DataType(DataType.Currency)]
        public double? Price { get; set; }
        public string Link { get; set; }

        public int Quantity { get; set; }
    }
}
