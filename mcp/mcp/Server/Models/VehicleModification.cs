using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mcp.Server.Models
{
    /// <summary>
    /// Used to represent a list of overall vehicle modifications, independent of projects
    /// </summary>
    public class VehicleModification
    {
        public int VehicleModificationID { get; set; }

        public int VehicleID { get; set; }
        public Vehicle Vehicle { get; set; }

        public int? UserCategoryID { get; set; }
        public UserCategory UserCategory { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public bool IsHighlighted { get; set; }
    }
}
