using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mcp.Server.Models
{
    public class Project
    {
        public int ProjectID { get; set; }

        public int VehicleID { get; set; }
        public Vehicle Vehicle { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public int? UserCategoryID { get; set; }
        public UserCategory UserCategory { get; set; }

        [DataType(DataType.Currency)]
        public decimal? TargetCost { get; set; }

        [DataType(DataType.Currency)]
        public decimal? ActualCost { get; set; }
        
        public DateTime? StartDate { get; set; }
        public DateTime? TargetEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }

        public bool IsComplete { get; set; }
        public bool IsPublic { get; set; }
        public bool IsCostPublic { get; set; }
        public bool IsDeleted { get; set; }
    }
}
